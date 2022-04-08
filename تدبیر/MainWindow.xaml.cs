using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BLL;

namespace تدبیر
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        PersnolBLL bll = new PersnolBLL();
        void openform(Form f)
        {

            Window g = FindName("main") as Window;
            BlurBitmapEffect blurBitmapEffect = new BlurBitmapEffect();
            blurBitmapEffect.Radius = 20;
            g.BitmapEffect = blurBitmapEffect;

            f.ShowDialog();
            blurBitmapEffect.Radius = 0;
            g.BitmapEffect = blurBitmapEffect;
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Persnolform person = new Persnolform();
            openform(person);
            personcont.Text = bll.readp();



        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Esthgagheform esthgagheform = new Esthgagheform();
            openform(esthgagheform);
            personcont.Text = bll.readp();
        }

        private void TextBlock_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            تشویقی tashveqhiform = new تشویقی();
            openform(tashveqhiform);
            personcont.Text = bll.readp();
        }

        private void TextBlock_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            استعلاجی estalhjeform = new استعلاجی();
            openform(estalhjeform);
            personcont.Text = bll.readp();
        }

        private void TextBlock_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            Mamoretform mamoretform = new Mamoretform();
            openform(mamoretform);
            personcont.Text = bll.readp();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            personcont.Text = bll.readp();
        }

        private void TextBlock_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
          
           
            
        }

      

        private void TextBlock_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TextBlock_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e)
        {
            drbarema drbarema = new drbarema();
            openform(drbarema);
        }
    }
}
