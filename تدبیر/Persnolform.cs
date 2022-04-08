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
    public partial class Persnolform : Form
    {
         void cleartext()
        {
            textBoxX1.Text = "";
            textBoxX2.Text="";
            textBoxX3.Text = "";


        }
        PersnolBLL bll = new PersnolBLL();
        public Persnolform()
        {
            InitializeComponent();
        }
        int id;
        private void labelX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (label4.Text == "ثبت پرسنل")
            {

            
            if (textBoxX2.Text.Length == 10)
            {
                Persnol p = new Persnol();
                p.NameFamily = textBoxX1.Text;
                p.Kodmili = textBoxX2.Text;
                p.roz = Convert.ToInt32(textBoxX3.Text);
                MessageBox.Show(bll.create(p));
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = bll.read();
                guna2DataGridView1.Focus();
                    cleartext();

                    labelX8.Text = guna2DataGridView1.RowCount.ToString();
                }
            else
            {
                MessageBox.Show("کدملی نباید بیشتر یا کمتر از 10 عدد باشد");
            }
                }
            else
            {
                Persnol p = new Persnol();
                p.NameFamily = textBoxX1.Text;
                p.Kodmili = textBoxX2.Text;
                p.roz = Convert.ToInt32(textBoxX3.Text);

              MessageBox.Show(bll.Update(p, id));
                label4.Text = "ثبت پرسنل";
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = bll.read();
                guna2DataGridView1.Focus();
                cleartext();
                labelX8.Text = guna2DataGridView1.RowCount.ToString();


            }
        }

        private void Persnolform_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.read();
            guna2DataGridView1.Focus();

            labelX8.Text = guna2DataGridView1.RowCount.ToString();
            
            
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.read(textBoxX4.Text);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Persnol p = bll.read(id);
                if (p !=null)
                {
                    textBoxX1.Text = p.NameFamily;
                    textBoxX2.Text = p.Kodmili;
                    textBoxX3.Text = Convert.ToString(p.roz);
                    label4.Text = "ویرایش پرسنل";
                }
               
            }
            catch (Exception)
            {

                
            }
            //Persnol p = bll.read(id);
            //textBoxX1.Text = p.NameFamily;
            //textBoxX2.Text = p.Kodmili;
            //textBoxX3.Text =Convert.ToString( p.roz);
            //label4.Text = "ویرایش پرسنل";
               
           

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("ایا میخواهید این پرسنل حذف شود؟", "حذف مرخصی", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(bll.Delete(id));

                    guna2DataGridView1.DataSource = null;
                    guna2DataGridView1.DataSource = bll.read();
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
            catch (Exception )
            {

               
            }
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      
    }
    

} 
