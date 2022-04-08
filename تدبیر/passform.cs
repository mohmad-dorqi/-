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
    public partial class passform : Form
    {
        public passform()
        {
            InitializeComponent();
        }
        userBLL bll = new userBLL();
        private void passform_Load(object sender, EventArgs e)
        {
            textBoxX4.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

        }
      
        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bll.reg2(textBoxX6.Text) == 1)
                {
                    textBoxX4.Visible = true;
                    label3.Visible = true;

                    textBoxX6.Visible = false;
                    label2.Visible = false;
                    label4.Visible =true ;
                }
            }
            catch (Exception)
            {

               
            }
          
           

        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User();
                var m = bll.Readk(textBoxX6.Text);
                if (m != null)
                {
                    u.Name = m.Name;
                    u.kodmli = m.kodmli;
                    u.Username = m.Username;
                    u.Password = textBoxX4.Text;
                    MessageBox.Show(bll.Update(u, textBoxX6.Text));
                    this.Close();

                }
                else
                {

                    MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد");
                }
            }
            catch (Exception)
            {

                
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
