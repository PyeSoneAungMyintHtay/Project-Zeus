using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Threading;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for single_user_window.xaml
    /// </summary>
    public partial class single_user_window : Window
    {
        public single_user_window()
        {
            InitializeComponent();
            load();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public string Query78;
        public string drug_name;
        public MySqlConnection conn = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                Query78 = "select drug_name from hopedatabase.drug where expire_date < ( CURRENT_DATE + INTERVAL 15 DAY );";
                MySqlCommand MyCommand2 = new MySqlCommand(Query78, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    drug_name = MyReader2.GetString(0);
                }
                MyReader2.Close();
                //conn.Close();
                if (drug_name != null)
                {
                    MessageBox.Show(drug_name + " drugs will be expire soon! \n CHECK YOUR DRUGS!");
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("d MMM yyyy hh:mm:ss tt");
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            ChangeAdminPasswordPage psw = new ChangeAdminPasswordPage();
            adminFrame.NavigationService.Navigate(psw);
        }

        private void HamburgerMenuItem_Selected_2(object sender, RoutedEventArgs e)
        {
            RegisterPatientPage RPP = new RegisterPatientPage();
            adminFrame.NavigationService.Navigate(RPP);
        }

        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            medicinePage mdP = new medicinePage();
            adminFrame.NavigationService.Navigate(mdP);
        }

        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {
            updateDoctorPage udP = new updateDoctorPage();
            adminFrame.NavigationService.Navigate(udP);
        }
    }
}
