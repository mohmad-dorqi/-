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
    public partial class backup : Form
    {
        public backup()
        {
            InitializeComponent();
        }
        backupBLL bll = new backupBLL();
        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("لطفا محل ذخیره سازی را انتخاب کنید","" ,  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FolderBrowserDialog fol = new FolderBrowserDialog();
                fol.ShowDialog();
                bll.backup(fol.SelectedPath);
                MessageBox.Show("پشتیبان گیری با موفقیت انجام شد");
            }
            catch (Exception s)
            {

                MessageBox.Show(" عملیات با خطا مواجه شد  "+s.Message);
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //try
            //{
                MessageBox.Show("بعد از انتخاب فایل وبازگردانی کردن تمام اطلاعات جدیدی که از انها پشتیبانی گرفته نشده حذف خواهند شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                OpenFileDialog fol = new OpenFileDialog();
                fol.ShowDialog();
                bll.restore(fol.FileName);
                MessageBox.Show("عملیات بازگردانی با موفقیت انجام شد");
            //}
            //catch (Exception s)
            //{

            //    MessageBox.Show("عملیات با خطا مواجه شد"+s.Message);
            //}
           
        }

        private void labelX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
