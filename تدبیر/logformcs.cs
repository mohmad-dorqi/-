using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System; //Given 
using System.Windows.Forms; //Given
using System.Windows.Forms.Integration; //Not so Given.
using System.Windows.Forms;
using BE;
using BLL;


namespace تدبیر
{
    public partial class logformcs : Form
    {
        public logformcs()
        {
            InitializeComponent();
        }
        userBLL bll = new userBLL();
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(textBoxX1.Text);
            string productKey = textBoxX2.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }

                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("نرم افزار با موفقیت فعالسازی شد", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxX3.Visible = true;
                    textBoxX4.Visible = true;
                    textBoxX5.Visible = true;
                    textBoxX6.Visible = true;
                    textBoxX1.Visible = false;
                    label2.Visible = true;
                   
                }
            }
            else
                MessageBox.Show("لایسنس وارد شده معتبر نمی باشد.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logformcs_Load(object sender, EventArgs e)
        {
            userBLL bll = new userBLL();
            if (bll.reg1()==1)
            {


               
                label2.Visible = false;
                textBoxX3.Visible = false;
                textBoxX4.Visible = false;
                textBoxX5.Visible = false;
                label2.Visible = false;
                label11.Visible = false;
                textBoxX1.Visible = false;
                textBoxX2.Visible = false;
                MessageBox.Show("شما قبلا لایسنس خود را دریافت کرده وثبتنام کردید لطفا با نام کاربری ورمز عبور وارد شوید");

                this.Close();
            }
            else
            {
                textBoxX1.Visible = true;
                textBoxX2.Visible = true;
                textBoxX1.Text = ComputerInfo.GetComputerId();
                textBoxX3.Visible = false;
                textBoxX4.Visible = false;
                textBoxX5.Visible = false;
                textBoxX6.Visible = false;

                label2.Visible = false;
             

            }



          

        }

        private void label2_Click(object sender, EventArgs e)
        {
            User u = new User();
            if (textBoxX4.Text.Count() >= 8 && textBoxX6.Text !=null && textBoxX3.Text !=null)
            {
                if (textBoxX5.Text.Length ==10)
                {
                    u.Name = textBoxX5.Text;
                    u.Username = textBoxX3.Text;
                    u.Password = textBoxX4.Text;
                    u.kodmli = textBoxX6.Text;
                    MessageBox.Show(bll.create(u));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("شماره کارت ملی صحیح نمی باشد");
                }
             
                

            }
            else
            {
                MessageBox.Show("رمز عبور باید بیشتر از 8 کارکتر باشد وتمام اطلاعات باید پر شود+");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

