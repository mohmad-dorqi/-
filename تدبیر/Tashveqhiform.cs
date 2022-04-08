using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using System.Windows.Forms;
using System.Globalization;

namespace تدبیر
{
    public partial class تشویقی : Form
    {
        public تشویقی()
        {
            InitializeComponent();
        }
        TashveqeBLL bll = new TashveqeBLL();
        PersnolBLL pbll = new PersnolBLL();
        Persnol p = new Persnol();
        int id;
       

        PersianCalendar PersianCalendar = new PersianCalendar();
        private void labelX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hide()
        {

           
            label4.Visible = false;
            label1.Visible = false;
         
        }
     
        private void label5_Click(object sender, EventArgs e)
        {
            try
            {

                if (label5.Text == "ثبت مرخصی")
                {



                    Tashveqhe t = new Tashveqhe();

                    t.Title = textBoxX6.Text;
                    t.Text = richTextBox1.Text;
                    t.Roztashveqh = Convert.ToInt32(textBoxX5.Text);
                    t.RegDate = DateTime.Now;
                    t.Tarekhtashveqh = textBoxX3.Text;
                    MessageBox.Show(bll.Create(t, p));
                    textBoxX2.Enabled = true;
                    textBoxX1.Enabled = true;
                    textBoxX1.Text = "";
                    textBoxX2.Text = "";
                    textBoxX5.Text = "";
                    textBoxX6.Text = "";
                    richTextBox1.Text = "";
                    label4.Visible = false;
                    label1.Visible = false;
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = bll.Read();
                    labelX8.Text = guna2DataGridView1.RowCount.ToString();

                }
                else
                {
                    Tashveqhe t = new Tashveqhe();

                    t.Title = textBoxX6.Text;
                    t.Roztashveqh = Convert.ToInt32(textBoxX5.Text);
                    t.Tarekhtashveqh = textBoxX3.Text;
                    t.Text = richTextBox1.Text;
                    MessageBox.Show(bll.Update(t, id));
                    textBoxX2.Enabled = true;
                    textBoxX1.Enabled = true;
                    textBoxX1.Text = "";
                    textBoxX2.Text = "";
                    textBoxX5.Text = "";
                    textBoxX6.Text = "";
                    textBoxX3.Text = "";
                    richTextBox1.Text = "";
                    label4.Visible = false;
                    label1.Visible = false;
                    label5.Text = "ثبت مرخصی";
                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = bll.Read();
                    labelX8.Text = guna2DataGridView1.RowCount.ToString();



                }
            }
            catch (Exception )
            {

            }


        }

        private void Tashveqhiform_Load(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {


            textBoxX1.Enabled = false;
            p = pbll.Readp(textBoxX1.Text);
            textBoxX2.Text = p.Kodmili;
            textBoxX2.Enabled = false;





        }

        private void label1_Click(object sender, EventArgs e)
        {



            textBoxX2.Enabled = false;
            p = pbll.Readk(textBoxX2.Text);

            textBoxX1.Text = p.NameFamily;
            textBoxX1.Enabled = false;


        }

        private void label9_Click(object sender, EventArgs e)
        {
            textBoxX2.Enabled = true;
            textBoxX1.Enabled = true;

            textBoxX1.Text = "";
            textBoxX2.Text = "";
            label4.Visible = false;
            label1.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;
            textBoxX2.Enabled = true;
            label1.Visible = true;
            label4.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = true;
            textBoxX2.Enabled = false;
            label4.Visible = true;
            label1.Visible = false;
        }
        
        
      

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tashveqhe t = bll.read(id);
                if (t !=null)
                {
                    textBoxX6.Text = t.Title;
                    textBoxX5.Text = Convert.ToString(t.Roztashveqh);
                    richTextBox1.Text = t.Text;
                    textBoxX3.Text = t.Tarekhtashveqh;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value;
            }
            catch (Exception)
            {

                
            }
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
         guna2DataGridView1.DataSource =   bll.Readt(textBoxX4.Text);
        }

     
    }
}
