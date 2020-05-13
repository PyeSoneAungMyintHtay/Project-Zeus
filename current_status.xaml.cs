using MySql.Data.MySqlClient;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for current_status.xaml
    /// </summary>
    public partial class current_status : Page
    {
        public current_status()
        {
            InitializeComponent();
        }
        public MySqlConnection conn = DBConnect.connectToDb();
        private char mode_t1 = '0',
         mode_t2 = '0',
         mode_t3 = '0',
         mode_t4 = '0',
         mode_t5 = '0',
         mode_t6 = '0',
         mode_t7 = '0',
         mode_t8 = '0',
         mode_t9 = '0',
         mode_t10 = '0',
         mode_t11 = '0',
         mode_t12 = '0',
         mode_t13 = '0',
         mode_t14 = '0',
         mode_t15 = '0',
         mode_t16 = '0',
         mode_t17 = '0',
         mode_t18 = '0',
         mode_t19 = '0',
         mode_t20 = '0',
         mode_t21 = '0',
         mode_t22 = '0',
         mode_t23 = '0',
         mode_t24 = '0',
         mode_t25 = '0',
         mode_t26 = '0',
         mode_t27 = '0',
         mode_t28 = '0',
         mode_t29 = '0',
         mode_t30 = '0',
         mode_t31 = '0',
         mode_t32 = '0';


        //private void t24_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (mode_t24 == '0')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_10.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '1';
        //    }
        //    else if (mode_t24 == '1')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '2';
        //    }
        //    else if (mode_t24 == '2')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_Ac_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '3';
        //    }
        //    else if (mode_t24 == '3')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_Ac.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '4';
        //    }
        //    else if (mode_t24 == '4')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_NiC_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '5';
        //    }
        //    else if (mode_t24 == '5')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_NiC.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '6';
        //    }
        //    else if (mode_t24 == '6')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_PFM_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '7';
        //    }
        //    else if (mode_t24 == '7')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_PFM.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '8';
        //    }
        //    else if (mode_t24 == '8')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_PoC_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '9';
        //    }
        //    else if (mode_t24 == '9')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_PoC.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'A';
        //    }
        //    else if (mode_t24 == 'A')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_Zr_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'B';
        //    }
        //    else if (mode_t24 == 'B')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_Zr.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'C';
        //    }
        //    else if (mode_t24 == 'C')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_support_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'D';
        //    }
        //    else if (mode_t24 == 'D')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_support.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'E';
        //    }
        //    else if (mode_t24 == 'E')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_Bdg.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'F';
        //    }
        //    else if (mode_t24 == 'F')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_implant.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = 'G';
        //    }
        //    else if (mode_t24 == 'G')
        //    {
        //        Uri resourceUri = new Uri("/image/tooth/24/ll1_24_nomal.png", UriKind.Relative);
        //        t24.Source = new BitmapImage(resourceUri);
        //        mode_t24 = '0';
        //    }
        //}

        private void t24_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ToothStatusWindow objToothStatusWindow = new ToothStatusWindow(24);
            objToothStatusWindow.Show();

        }

        private void t16_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t16 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul8_16_10.png", UriKind.Relative);
                t16.Source = new BitmapImage(resourceUri);
                mode_t16 = '1';
            }
            else if (mode_t16 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul8_16.png", UriKind.Relative);
                t16.Source = new BitmapImage(resourceUri);
                mode_t16 = '0';
            }
        }

        private void t15_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t15 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul7_15_10.png", UriKind.Relative);
                t15.Source = new BitmapImage(resourceUri);
                mode_t15 = '1';
            }
            else if (mode_t15 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul7_15.png", UriKind.Relative);
                t15.Source = new BitmapImage(resourceUri);
                mode_t15 = '0';
            }
        }

        private void t14_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t14 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul6_14_10.png", UriKind.Relative);
                t14.Source = new BitmapImage(resourceUri);
                mode_t14 = '1';
            }
            else if (mode_t14 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul6_14.png", UriKind.Relative);
                t14.Source = new BitmapImage(resourceUri);
                mode_t14 = '0';
            }
        }

        private void t13_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t13 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul5_13_10.png", UriKind.Relative);
                t13.Source = new BitmapImage(resourceUri);
                mode_t13 = '1';
            }
            else if (mode_t13 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul5_13.png", UriKind.Relative);
                t13.Source = new BitmapImage(resourceUri);
                mode_t13 = '0';
            }
        }

        private void t12_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t12 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul4_12_10.png", UriKind.Relative);
                t12.Source = new BitmapImage(resourceUri);
                mode_t12 = '1';
            }
            else if (mode_t12 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul4_12.png", UriKind.Relative);
                t12.Source = new BitmapImage(resourceUri);
                mode_t12 = '0';
            }
        }

        private void t11_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t11 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul3_11_10.png", UriKind.Relative);
                t11.Source = new BitmapImage(resourceUri);
                mode_t11 = '1';
            }
            else if (mode_t11 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul3_11.png", UriKind.Relative);
                t11.Source = new BitmapImage(resourceUri);
                mode_t11 = '0';
            }
        }

        private void t10_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t10 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul2_10_10.png", UriKind.Relative);
                t10.Source = new BitmapImage(resourceUri);
                mode_t10 = '1';
            }
            else if (mode_t10 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul2_10.png", UriKind.Relative);
                t10.Source = new BitmapImage(resourceUri);
                mode_t10 = '0';
            }
        }

        private void t9_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t9 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ul1_9_10.png", UriKind.Relative);
                t9.Source = new BitmapImage(resourceUri);
                mode_t9 = '1';
            }
            else if (mode_t9 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ul1_9.png", UriKind.Relative);
                t9.Source = new BitmapImage(resourceUri);
                mode_t9 = '0';
            }
        }

        private void t8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t8 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur1_8_10.png", UriKind.Relative);
                t8.Source = new BitmapImage(resourceUri);
                mode_t8 = '1';
            }
            else if (mode_t8 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur1_8.png", UriKind.Relative);
                t8.Source = new BitmapImage(resourceUri);
                mode_t8 = '0';
            }
        }

        private void t7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t7 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur2_7_10.png", UriKind.Relative);
                t7.Source = new BitmapImage(resourceUri);
                mode_t7 = '1';
            }
            else if (mode_t7 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur2_7.png", UriKind.Relative);
                t7.Source = new BitmapImage(resourceUri);
                mode_t7 = '0';
            }
        }

        private void t6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t6 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur3_6_10.png", UriKind.Relative);
                t6.Source = new BitmapImage(resourceUri);
                mode_t6 = '1';
            }
            else if (mode_t6 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur3_6.png", UriKind.Relative);
                t6.Source = new BitmapImage(resourceUri);
                mode_t6 = '0';
            }
        }

        private void t1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t1 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur8_1_10.png", UriKind.Relative);
                t1.Source = new BitmapImage(resourceUri);
                mode_t1 = '1';
            }
            else if (mode_t1 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur8_1.png", UriKind.Relative);
                t1.Source = new BitmapImage(resourceUri);
                mode_t1 = '0';
            }
        }

        private void t2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t2 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur7_2_10.png", UriKind.Relative);
                t2.Source = new BitmapImage(resourceUri);
                mode_t2 = '1';
            }
            else if (mode_t2 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur7_2.png", UriKind.Relative);
                t2.Source = new BitmapImage(resourceUri);
                mode_t2 = '0';
            }
        }

        private void t3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t3 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur6_3_10.png", UriKind.Relative);
                t3.Source = new BitmapImage(resourceUri);
                mode_t3 = '1';
            }
            else if (mode_t3 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur6_3.png", UriKind.Relative);
                t3.Source = new BitmapImage(resourceUri);
                mode_t3 = '0';
            }
        }

        private void t4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t4 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur5_4_10.png", UriKind.Relative);
                t4.Source = new BitmapImage(resourceUri);
                mode_t4 = '1';
            }
            else if (mode_t4 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur5_4.png", UriKind.Relative);
                t4.Source = new BitmapImage(resourceUri);
                mode_t4 = '0';
            }
        }

        private void t5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode_t5 == '0')
            {
                Uri resourceUri = new Uri("/image/tooth/ur4_5_10.png", UriKind.Relative);
                t5.Source = new BitmapImage(resourceUri);
                mode_t5 = '1';
            }
            else if (mode_t5 == '1')
            {
                Uri resourceUri = new Uri("/image/tooth/ur4_5.png", UriKind.Relative);
                t5.Source = new BitmapImage(resourceUri);
                mode_t5 = '0';
            }
        }
    }
}