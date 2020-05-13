using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for treatmentPage.xaml
    /// </summary>
    public partial class treatmentPage : Page
    {
        public treatmentPage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT * from hopedatabase.treatment;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);

                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
                time_require.IsEnabled = false;
                cost.IsEnabled = false;
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

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hopedatabase.treatment where treatment_id='" + treatment_ID.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Treatment Deleted");
                treatment_ID.Text = ""; time_require.Text = ""; cost.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                treatment_ID.Text = row["treatment_ID"].ToString();
                treatment_name.Text = row["treatment_name"].ToString();
                time_require.Text = row["time_require"].ToString();
                cost.Text = row["cost"].ToString();

                button_add.IsEnabled = false;
                button_update.IsEnabled = true;
            }
            catch { }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into hopedatabase.treatment (`treatment_ID`, `treatment_name`, `time_require`, `cost`) values('" + treatment_ID.Text + "','" + treatment_name.Text + "','" + time_require.Text + "','" + cost.Text + "');";
            MySqlCommand MyCommand = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            MyReader.Close();

            MessageBox.Show("Treatment Registered");

            treatment_ID.Text = ""; treatment_name.Text = ""; time_require.Text = ""; cost.Text = "";
            load();
            treatment_name.IsEnabled = false; time_require.IsEnabled = false; cost.IsEnabled = false;
        }

        private void treatment_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            treatment_name.IsEnabled = true;
        }

        private void treatment_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            time_require.IsEnabled = true;
        }

        private void time_require_TextChanged(object sender, TextChangedEventArgs e)
        {
            cost.IsEnabled = true;
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hopedatabase.treatment set treatment_name = '" + treatment_name.Text + "', time_require = '" + time_require.Text + "', cost = '" + cost.Text + "' where (treatment_ID = '" + treatment_ID.Text + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show(" Updated Succesfully");
                treatment_ID.Text = ""; treatment_name.Text = ""; time_require.Text = ""; cost.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}