using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for updateDoctorPage.xaml
    /// </summary>
    public partial class updateDoctorPage : Page
    {
        public updateDoctorPage()
        {
            InitializeComponent();
            loadDoctor();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void loadDoctor()
        {
            try
            {
                string sql = "SELECT doctor_name,doctor_degree,register_number from hopedatabase.doctor_info where doctor_id='1';";
                MySqlCommand MyCommand = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    doctor_name.Text = MyReader.GetString(0).ToString();
                    doctor_degree.Text = MyReader.GetString(1).ToString();
                    register_number.Text = MyReader.GetString(2).ToString();
                }
                MyReader.Close();
                //conn.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hopedatabase.doctor_info set doctor_name = '" + doctor_name.Text + "', doctor_degree = '" + doctor_degree.Text + "', register_number = '" + register_number.Text + "' where ( doctor_id = '1' );";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show(" Updated Succesfully");
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}