using System;
using System.Windows.Forms;
using static FruitTest.DBService;

namespace FruitTest
{
    public partial class Form2 : Form
    {
        readonly DBService db;

        public Form2()
        {
            InitializeComponent();
            db = new DBService();
            db.FillComboBoxFromDB( cmbTraders, "Traders", "w_id", "w_name" );
            db.FillComboBoxFromDB( cmbGoods, "Goods", "w_id", "w_name" );
            cmbTraders.SelectedIndex = 0;
            cmbGoods.SelectedIndex = 0;
        }

        private void Form2_FormClosing( object sender, FormClosingEventArgs e )
        {
            db.Close();
        }

        private void btWrite_Click( object sender, EventArgs e )
        {
            (bool b_weight, double d_weight) = Validator.IsValid( tbWeight.Text );
            (bool b_price, double d_price) = Validator.IsValid( tbPrice.Text );

            if ( b_weight && b_price )
            {
                db.ShipmWrite(
                    dateTimePicker1.Value.Date,
                    ( cmbTraders.SelectedItem as ComboboxItem ).Value,
                    ( cmbGoods.SelectedItem as ComboboxItem ).Value,
                    d_weight,
                    d_price );
                MessageBox.Show( "Запись завершена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information );
                tbWeight.Text = "0,0";
                tbPrice.Text = "0,00";
                return;
            }
            MessageBox.Show( "Не корректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
    }
}
