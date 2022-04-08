using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;


namespace تدبیر
{
    public partial class استعلاجی : Form
    {
        public استعلاجی()
        {
            InitializeComponent();
        }
        AestalajeBLL bll = new AestalajeBLL();
        PersnolBLL pbll = new PersnolBLL();
        Persnol p = new Persnol();
        int id;
        private void labelX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hide()
        {


            label13.Visible = false;
            label9.Visible = false;

        }
        private void label11_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;
            label9.Visible = true;
            label13.Visible = false;
            textBoxX2.Focus();
        }

        private void label12_Click(object sender, EventArgs e)
        {
           
            textBoxX1.Enabled = true;
            textBoxX2.Enabled = false;
            label13.Visible = true;
            label9.Visible = false;
            textBoxX1.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBoxX2.Enabled = true;
            textBoxX1.Enabled = true;

            textBoxX1.Text = "";
            textBoxX2.Text = "";
            label13.Visible = false;
            label9.Visible = false;
            textBoxX1.Focus();
        }

        private void estalhjeform_Load(object sender, EventArgs e)
        {
            hide();
            AutoCompleteStringCollection person = new AutoCompleteStringCollection();
            foreach (var item in pbll.readpersonl())
            {
                person.Add(item);
            }
            textBoxX1.AutoCompleteCustomSource = person;
            AutoCompleteStringCollection person2 = new AutoCompleteStringCollection();
            foreach (var item in pbll.readpersonl2())
            {
                person2.Add(item);
            }
            textBoxX2.AutoCompleteCustomSource = person2;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read();
            labelX8.Text = guna2DataGridView1.RowCount.ToString();

        }

        private void label13_Click(object sender, EventArgs e)
        {

            textBoxX1.Enabled = false;
            p = pbll.Readp(textBoxX1.Text);
            textBoxX2.Text = p.Kodmili;
            textBoxX2.Enabled = false;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read(textBoxX1.Text);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            textBoxX2.Enabled = false;
            p = pbll.Readk(textBoxX2.Text);

            textBoxX1.Text = p.NameFamily;
            textBoxX1.Enabled = false;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read(textBoxX2.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "ثبت مرخصی")
            {


                Astalaje a = new Astalaje();



                a.Title = textBoxX6.Text;
                a.Text = richTextBox1.Text;
                a.RoztAstlaje = Convert.ToInt32(textBoxX5.Text);
                a.RegDate = DateTime.Now;
                a.TarekhtAstlaje = textBoxX3.Text;
                MessageBox.Show(bll.Create(a, p));

                textBoxX2.Enabled = true;
                textBoxX1.Enabled = true;
                textBoxX1.Text = "";
                textBoxX2.Text = "";
                textBoxX5.Text = "";
                textBoxX6.Text = "";

                richTextBox1.Text = "";
                label9.Visible = false;
                label13.Visible = false;
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = bll.Read();
                labelX8.Text = guna2DataGridView1.RowCount.ToString();
            }
            else
            {
                Astalaje a = new Astalaje();
                //   t.Persnol.NameFamily = textBoxX1.Text;
                //    t.Persnol.Kodmili = textBoxX2.Text;
                a.Title = textBoxX6.Text;
                a.RoztAstlaje = Convert.ToInt32(textBoxX5.Text);
                a.TarekhtAstlaje = textBoxX3.Text;
                a.Text = richTextBox1.Text;
                MessageBox.Show(bll.Update(a, id));
                textBoxX2.Enabled = true;
                textBoxX1.Enabled = true;
                textBoxX1.Text = "";
                textBoxX2.Text = "";
                textBoxX5.Text = "";
                textBoxX6.Text = "";
                textBoxX3.Text = "";
                richTextBox1.Text = "";
                label4.Visible = false;              
                label5.Text = "ثبت مرخصی";
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = bll.Read();
                labelX8.Text = guna2DataGridView1.RowCount.ToString();



            }

        }

       
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Astalaje a = bll.read(id);
                if (a != null)
                {
                    textBoxX6.Text = a.Title;
                    textBoxX5.Text = Convert.ToString(a.RoztAstlaje);
                    richTextBox1.Text = a.Text;
                    textBoxX3.Text = a.TarekhtAstlaje;
                    label5.Text = "ثبت ویرایش";
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = bll.Read();
                }
               
            }
            catch (Exception)
            {

               
            }
         
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("ایا میخواهید این مرخصی حذف شود؟", "حذف مرخصی", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(bll.Delete(id));
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = bll.Read();
                    guna2DataGridView1.Focus();
                    labelX8.Text = guna2DataGridView1.RowCount.ToString();

                }
            }
            catch (Exception)
            {

               
            }
        
               
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Readt(textBoxX7.Text);
        }
    }
}
