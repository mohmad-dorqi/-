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
    public partial class Esthgagheform : Form
    {
        public Esthgagheform()
        {
            InitializeComponent();
        }
       EsthqaqeBLL  bll = new EsthqaqeBLL();
        //برای ایجاد حالت پیشنهاد باید از کلاس های زیر نمونه گیری کرد
        PersnolBLL pbll = new PersnolBLL();
        Persnol p = new Persnol();
        int id ;
        int idp;
        int roz;
        int rozp;
        private void labelX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hide()
        {


            label13.Visible = false;
            label9.Visible = false;

        }
        private void Esthgagheform_Load(object sender, EventArgs e)
        {
            
            // فعل عاید برای مخفی کردن لیبل ها
            //بقیه کدها برای ایجاد حالت پیشنهاد در تکست باکس
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

        private void label11_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;
            textBoxX3.Enabled = false;
            textBoxX2.Enabled = true;
            label9.Visible = true;
            label13.Visible = false;
            textBoxX2.Focus();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBoxX3.Enabled = false;
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

        private void label13_Click(object sender, EventArgs e)
        {
           
            textBoxX1.Enabled = false;
            p = pbll.Readp(textBoxX1.Text);
            textBoxX2.Text = p.Kodmili;
            textBoxX3.Text = Convert.ToString(p.roz);
            textBoxX3.Enabled = false;
            textBoxX2.Enabled = false;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read(textBoxX1.Text);
        }
        
        private void label9_Click(object sender, EventArgs e)
        {

            textBoxX2.Enabled = false;
            p = pbll.Readk(textBoxX2.Text);
            textBoxX3.Text = Convert.ToString(p.roz);
            textBoxX3.Enabled = false;
            textBoxX1.Text = p.NameFamily;
            textBoxX1.Enabled = false;
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Read(textBoxX2.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "ثبت مرخصی") 
            { 
               if (textBoxX3.Text == "0")
                 {
                 MessageBox.Show("مرخصی های این پرسنل به اتمام رسیده است.امکان ثبت مرخصی جدید وجود ندارد");
                 }
                 else
                 {
                    Esthqhaqhe es = new Esthqhaqhe();



                    es.Title = textBoxX6.Text;
                    es.Text = richTextBox1.Text;
                    es.RozAsthqaqe = Convert.ToInt32(textBoxX5.Text);
                    es.RegDate = DateTime.Now;
                    es.TarekhAsthqaqe = textBoxX4.Text;
                    Persnol P2 = pbll.Readk(textBoxX2.Text);
                    Persnol p3 = new Persnol();
                    int a = Convert.ToInt32(textBoxX5.Text);
                    int b = Convert.ToInt32(textBoxX3.Text);
                    p3.roz = b - a;
                    p3.NameFamily = P2.NameFamily;
                    p3.Kodmili = P2.Kodmili;
                    pbll.Updatek(p3, textBoxX2.Text);
                    if (p3.roz < 0)
                    {
                        MessageBox.Show("مرخصی درخواستی کمتر از باقیمانده است");
                    }
                    else
                    {
                        MessageBox.Show(bll.Create(es, p));

                        textBoxX2.Enabled = true;
                        textBoxX1.Enabled = true;
                        textBoxX1.Text = "";
                        textBoxX2.Text = "";
                        textBoxX5.Text = "";
                        textBoxX6.Text = "";
                        textBoxX3.Text = "";
                        textBoxX4.Text = "";
                        richTextBox1.Text = "";
                        label9.Visible = false;
                        label13.Visible = false;
                        guna2DataGridView1.DataSource = null;
                        guna2DataGridView1.DataSource = bll.Read();
                        labelX8.Text = guna2DataGridView1.RowCount.ToString();


                    }
                }
            }
            else
            {
                Esthqhaqhe es = new Esthqhaqhe();
                //   t.Persnol.NameFamily = textBoxX1.Text;
                //    t.Persnol.Kodmili = textBoxX2.Text;
                es.Title = textBoxX6.Text;
                es.RozAsthqaqe = Convert.ToInt32(textBoxX5.Text);
                es.TarekhAsthqaqe = textBoxX4.Text;
                es.Text = richTextBox1.Text;
                Persnol p = pbll.read(idp);
                Persnol p3 = new Persnol();
                int a = Convert.ToInt32( textBoxX5.Text);
                int b = rozp;
                p3.roz = b - a;
                p3.NameFamily = p.NameFamily;
                p3.Kodmili = p.Kodmili;
                pbll.Update(p3, idp);
                MessageBox.Show(bll.Update(es, id));
                textBoxX2.Enabled = true;
                textBoxX1.Enabled = true;
                textBoxX1.Text = "";
                textBoxX2.Text = "";
                textBoxX5.Text = "";
                textBoxX6.Text = "";
                richTextBox1.Text = "";
                label4.Visible = false;
                label1.Visible = false;
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
                Esthqhaqhe es = bll.read(id);
                if (es !=null)
                {
                    textBoxX6.Text = es.Title;
                    textBoxX5.Text = Convert.ToString(es.RozAsthqaqe);
                    textBoxX4.Text = es.TarekhAsthqaqe;
                    richTextBox1.Text = es.Text;
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
                    Persnol P = pbll.read(idp);
                    Persnol p3 = new Persnol();
                    int a = roz;
                    int b = rozp;
                    p3.roz = b + a;
                    p3.NameFamily = p.NameFamily;
                    p3.Kodmili = p.Kodmili;
                    pbll.Update(p3, idp);

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
                idp = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value;
                rozp = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value;
                roz = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value;
            }
            catch (Exception)
            {


            }

        }

        private void textBoxX7_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = bll.Readt(textBoxX7.Text);
        }
    }
}
