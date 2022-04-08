using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BLL;

namespace تدبیر
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        userBLL ubll = new userBLL();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logformcs logformcs = new logformcs();
            logformcs.ShowDialog();
        }
        userBLL bll = new userBLL();
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {

        }
        PersnolBLL pbll = new PersnolBLL();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (bll.read(usertxt.Text,  passbox.Password ) == 1)
            {

                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();

               

                

            }
            else
            {
                MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد");
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            passform passform = new passform();
            passform.ShowDialog();
        }

        private void passtxt1_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            backup backup = new backup();
            this.Close();
            backup.ShowDialog();
        }
    }
}
