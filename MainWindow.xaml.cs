/*
   Code history
     0001
   Date
     13th May, 2020.
   Programmer
     Pye Sone Aung Myint Htay
   Project name:
     project Zeus ( test software for Dentists )
   Version
     20.05
   Copyright:
     (c)hopeelectronics, 2020.
   Revision History:
     13.05.2020:	upload my old project to GIT
                    This is master
   Description:
     Software for dentists
   NOTES:
     
*/

using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Threading;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            combobox.Items.Add("Single_User");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //lblTime.Content = DateTime.Now.ToLongTimeString();
            lblTime.Content = DateTime.Now.ToString("d MMM yyyy hh:mm:ss tt");
            //       d: 6/15/2008
            //       D: Sunday, June 15, 2008
            //       f: Sunday, June 15, 2008 9:15 PM
            //       F: Sunday, June 15, 2008 9:15:07 PM
            //       g: 6/15/2008 9:15 PM
            //       G: 6/15/2008 9:15:07 PM
            //       m: June 15
            //       o: 2008-06-15T21:15:07.0000000
            //       R: Sun, 15 Jun 2008 21:15:07 GMT
            //       s: 2008-06-15T21:15:07
            //       t: 9:15 PM
            //       T: 9:15:07 PM
            //       u: 2008-06-15 21:15:07Z
            //       U: Monday, June 16, 2008 4:15:07 AM
            //       y: June, 2008
            //
            //       'h:mm:ss.ff t': 9:15:07.00 P
            //       'd MMM yyyy': 15 Jun 2008
            //       'HH:mm:ss.f': 21:15:07.0
            //       'dd MMM HH:mm:ss': 15 Jun 21:15:07
            //       '\Mon\t\h\: M': Month: 6
            //       'HH:mm:ss.ffffzzz': 21:15:07.0000-07:00
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem == null)
            {
                MessageBox.Show("Please choose an option");
            }
            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from hopedatabase.admin where NAME='" + textboxUsername.Text + "' and PASSWORD='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        single_user objSingleWindow = new single_user();
                        objSingleWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}