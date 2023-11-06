using last_na_talaga_toh_pramis.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace last_na_talaga_toh_pramis
{
    public partial class Form3 : Form
    {
     
        
        public Form3()
        {
            InitializeComponent();
           
        }

        public void total_price()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);

            }
            lbl_totalAmount.Text = "PHP: " + sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            aub3 frm = new aub3();
             frm.Show();

        }

        private void btn_espresso_Click(object sender, EventArgs e)
        {
            int a = 100;
            decimal b = numb.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Espresso", price);
            total_price();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btn_coffee_Click(object sender, EventArgs e)
        {
            panel_order.Show();
            panpastries.Hide();

        }

        private void btn_patries_Click(object sender, EventArgs e)
        {
           
            panpastries.Show();
            panel_order.Hide();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            lbl_totalAmount.Text = string.Empty;
        }

        private void btn_doppio_Click(object sender, EventArgs e)
        {
            int a = 120;
            decimal b = numd.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Doppio", price);
            total_price();
        }

        private void btn_Americano_Click(object sender, EventArgs e)
        {
            int a = 165;
            decimal b = numa.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Americo", price);
            total_price();
        }

        private void btn_esMacchiato_Click(object sender, EventArgs e)
        {
            int a = 190;
            decimal b = numes.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "esMacchiato", price);
            total_price();
        }

        private void btn_latte_Click(object sender, EventArgs e)
        {
            int a = 140;
            decimal b = numl.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Latte", price);
            total_price();
        }

        private void btn_cuppoccino_Click(object sender, EventArgs e)
        {
            int a = 170;
            decimal b = numc.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Cuppoccino", price);
            total_price();
        }

        private void btn_irish_Click(object sender, EventArgs e)
        {
            int a = 185;
            decimal b = numoc.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Irish", price);
            total_price();
        }

        private void btn_mocha_Click(object sender, EventArgs e)
        {
            int a = 210;
            decimal b = numb.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Mocha", price);
            total_price();
        }

        private void btn_caramel_Click(object sender, EventArgs e)
        {
            int a = 200;
            decimal b = numcar.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Caramel", price);
            total_price();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            int a = 250;
            decimal b = numb.Value;

            decimal price;
            price = a * b;
            dataGridView1.Rows.Add(b, "Bananacake", price);
            total_price();
        }

        private void lblback_Click(object sender, EventArgs e)
        {
            aub3 frm1 = new aub3();
            this.Close();
            frm1.Show();
        }

        private void clear_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            lbl_totalAmount.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
