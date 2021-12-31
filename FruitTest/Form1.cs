using System;
using System.Windows.Forms;

namespace FruitTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_acceptance_Click( object sender, EventArgs e )
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void bt_report_Click( object sender, EventArgs e )
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
