using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.ComponentModel;

namespace FruitTest
{
    internal class DBService
    {
        private static readonly string connstr =
            $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Application.StartupPath}\Fruit.mdb;";
        private readonly OleDbConnection connect;

        public DBService()
        {
            connect = new OleDbConnection( connstr );
            connect.Open();
        }

        public void Close()
        {
            connect.Close();
        }


        /// <summary>
        /// Заполнение элементов комбоксов из БД
        /// </summary>
        /// <param name="cmb">Комбобокс</param>
        /// <param name="tablename">Имя таблицы</param>
        /// <param name="idfield">Поле ID</param>
        /// <param name="namefield">Поле NAME</param>
        public void FillComboBoxFromDB(
            ComboBox cmb
          , string tablename
          , string idfield
          , string namefield )
        {
            cmb.Items.Clear();
            string sql = "SELECT " + idfield + ", " + namefield + " FROM " + tablename + " ORDER BY " + namefield;
            OleDbCommand command = new OleDbCommand( sql, connect );
            OleDbDataReader reader = command.ExecuteReader();

            if ( reader.HasRows )
            {
                while ( reader.Read() )
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Value = reader.GetInt32( 0 );
                    item.Text = reader.GetString( 1 );
                    cmb.Items.Add( item );
                }
                reader.Close();
            }     
        }


        /// <summary>
        /// Запись поступлений товаров в БД
        /// </summary>
        /// <param name="date">Дата поступления</param>
        /// <param name="trader">Поставщик</param>
        /// <param name="good">Товар</param>
        /// <param name="weight">Вес</param>
        /// <param name="price">Цена за 1 кг.</param>
        public void ShipmWrite( DateTime date, int trader, int good, double weight, double price )
        {
            string sql = "INSERT INTO Shipment (w_date, w_trader, w_goods, w_weight, w_price) " +
                $"VALUES ('{date}', '{trader}', '{good}', '{weight}', '{price}')";
            OleDbCommand command = new OleDbCommand( sql, connect );
            command.ExecuteNonQuery();
        }


        /// <summary>
        /// Вспомогательный класс для элемента меню комбокса
        /// </summary>
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }


        /// <summary>
        /// Вывод отчета о поставках
        /// </summary>
        /// <param name="d1">Начальная дата отчета</param>
        /// <param name="d2">Конечная дата отчета</param>
        /// <param name="list">Модель привязки к ДатаГриду</param>
        public void ReportRead( DateTime d1, DateTime d2, ref BindingList<DataGridModel> list )
        {
            string sql = "SELECT S.w_date, (SELECT w_name FROM Traders WHERE w_id = S.w_trader), " +
                "(SELECT w_name FROM Goods WHERE w_id = S.w_goods), w_weight, w_price FROM Shipment S " +
                "WHERE w_date BETWEEN @dt_start AND @dt_end ORDER BY w_date";

            OleDbCommand command = new OleDbCommand( sql, connect );
            command.Parameters.Add( "@dt_start", OleDbType.Date ).Value = d1.Date;
            command.Parameters.Add( "@dt_end", OleDbType.Date ).Value = d2.Date;
            OleDbDataReader reader = command.ExecuteReader();

            if ( reader.HasRows )
            {
                while ( reader.Read() )
                {
                    list.Add( new DataGridModel()
                    {
                        Date = reader.GetDateTime( 0 ).Date,
                        Trader = reader.GetString( 1 ),
                        Good = reader.GetString( 2 ),
                        Weight = reader.GetDouble( 3 ),
                        Price = reader.GetDouble( 4 ),
                        Cost = Math.Round( reader.GetDouble( 3 ) * reader.GetDouble( 4 ), 2 )
                    } );
                }
                reader.Close();
            }
        }

    }
}
