using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace تدبیر
{
    public partial class Mamoretform : Form
    {
        public Mamoretform()
        {
            InitializeComponent();
        }
        PersnolBLL pbll = new PersnolBLL();
        Persnol p = new Persnol();
        MamoretBLL bll = new MamoretBLL();
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
        private void Mamoretform_Load(object sender, EventArgs e)
        {
            hide();
            textBoxX1.Focus();
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
            textBoxX2.Enabled = true;
            textBoxX1.Enabled = true;

            textBoxX1.Text = "";
            textBoxX2.Text = "";
            label13.Visible = false;
            label9.Visible = false;
            textBoxX1.Focus();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;         
            textBoxX2.Enabled = true;
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
            if (label5.Text == "ثبت ماموریت")
            {
                Mamoret m = new Mamoret();



                m.Title = textBoxX6.Text;
                m.Text = richTextBox1.Text;
                
                m.RegDate = DateTime.Now;
                m.TarekMamoret = textBoxX3.Text;
                MessageBox.Show(bll.Create(m, p));

                textBoxX2.Enabled = true;
                textBoxX1.Enabled = true;
                textBoxX1.Text = "";
                textBoxX2.Text = "";            
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
                Mamoret m = new Mamoret();
                //   t.Persnol.NameFamily = textBoxX1.Text;
                //    t.Persnol.Kodmili = textBoxX2.Text;
                m.Title = textBoxX6.Text;
              
                m.TarekMamoret = textBoxX3.Text;
                m.Text = richTextBox1.Text;
                MessageBox.Show(bll.Update(m, id));
                textBoxX2.Enabled = true;
                textBoxX1.Enabled = true;
                textBoxX1.Text = "";
                textBoxX2.Text = "";
                textBoxX3.Text = "";
                textBoxX6.Text = "";
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
                Mamoret m = bll.read(id);
                if (m != null)
                {
                    textBoxX6.Text = m.Title;
                    textBoxX3.Text = m.TarekMamoret;
                    richTextBox1.Text = m.Text;
                    label5.Text = "ویرایش مرخصی";
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

                
            }
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Readt(textBoxX4.Text);
        }
    }
    
}
