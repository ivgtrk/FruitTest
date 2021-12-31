using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FruitTest
{
    public partial class Form3 : Form
    {
        readonly DBService db;
        private BindingList<DataGridModel> DgvModels;

        public Form3()
        {
            InitializeComponent();
            db = new DBService();
            btShow.Select();

            DgvModels = new BindingList<DataGridModel>();
            dgv1.DataSource = DgvModels;

            dtp2.MinDate = DateTime.Now;
        }

        private void Form3_FormClosing( object sender, FormClosingEventArgs e )
        {
            db.Close();
        }

        private void btShow_Click( object sender, EventArgs e )
        {
            DgvModels.Clear();
            db.ReportRead( dtp1.Value, dtp2.Value, ref DgvModels );
        }

        private void dtp1_ValueChanged( object sender, EventArgs e )
        {
            dtp2.MinDate = dtp1.Value;
        }
    }
}
