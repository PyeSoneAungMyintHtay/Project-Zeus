using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for diagnosisPage.xaml
    /// </summary>
    public partial class diagnosisPage : Page
    {
        public diagnosisPage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT * from hopedatabase.disease;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);

                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
                disease_type.IsEnabled = false;
                disease_name.IsEnabled = false;
                button_add.IsEnabled = true;
                button_update.IsEnabled = false;
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

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                disease_id.Text = row["disease_id"].ToString();
                disease_type.Text = row["disease_type"].ToString();
                disease_name.Text = row["disease_name"].ToString();
                button_add.IsEnabled = false;
                button_update.IsEnabled = true;
            }
            catch { }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into hopedatabase.disease (`disease_id`, `disease_type`, `disease_name`) values('" + disease_id.Text + "','" + disease_type.Text + "','" + disease_name.Text + "');";
            MySqlCommand MyCommand = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            MyReader.Close();

            MessageBox.Show("Disease Registered");

            disease_id.Text = ""; disease_type.Text = ""; disease_name.Text = "";
            load();
            disease_type.IsEnabled = false; disease_name.IsEnabled = false;
        }

        private void disease_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            disease_type.IsEnabled = true;
        }

        private void disease_type_TextChanged(object sender, TextChangedEventArgs e)
        {
            disease_name.IsEnabled = true;
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hopedatabase.disease where disease_id='" + disease_id.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Disease Deleted");
                disease_id.Text = ""; disease_type.Text = ""; disease_name.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            string sql = "update hopedatabase.disease set disease_type = '" + disease_type.Text + "', disease_name = '" + disease_name.Text + "' where (disease_id = '" + disease_id.Text + "');";
            MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            MyReader2.Close();
            MessageBox.Show(" Updated Succesfully");
            disease_id.Text = ""; disease_type.Text = ""; disease_name.Text = "";
            load();
        }
    }
}