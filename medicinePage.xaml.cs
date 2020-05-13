using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for medicinePage.xaml
    /// </summary>
    public partial class medicinePage : Page
    {
        public medicinePage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT * from hopedatabase.drug;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);

                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
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
                string sql = "delete from hopedatabase.drug where drug_ID='" + drug_ID.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Drug Deleted");
                drug_ID.Text = ""; drug_name.Text = ""; expire_date.Text = ""; buy_price.Text = ""; sell_price.Text = ""; drug_type.Text = "";
                load();
                drug_name.IsEnabled = false; expire_date.IsEnabled = false; buy_price.IsEnabled = false; sell_price.IsEnabled = false; drug_type.IsEnabled = false;
                quantity.IsEnabled = false;
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

                drug_ID.Text = row["drug_ID"].ToString();
                drug_name.Text = row["drug_name"].ToString();
                var buff = row["expire_date"].ToString();
                expire_date.Text = Convert.ToDateTime(buff).ToString("yyyy/MM/dd");
                //expire_date.Text = row["expire_date"].ToString();
                //private void datepicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
                //{
                //    buy_price.IsEnabled = true;

                //    //var date = Convert.ToDateTime(datepicker.Text).ToString("yyyy/MM/dd");
                //    //datepicker.Text = date;
                //}
                buy_price.Text = row["buy_price"].ToString();
                sell_price.Text = row["sell_price"].ToString();
                quantity.Text = row["quantity"].ToString();
                drug_type.Text = row["drug_type"].ToString();
                button_add.IsEnabled = false;
                button_update.IsEnabled = true;
            }
            catch { }
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var date =
                string sql = "update hopedatabase.drug set drug_name = '" + drug_name.Text + "', expire_date = '" + expire_date.Text + "', buy_price = '" + buy_price.Text + "', sell_price = '" + sell_price.Text + "', quantity = '" + quantity.Text + "', drug_type = '" + drug_type.Text + "' where (drug_ID = '" + drug_ID.Text + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show(" Updated Succesfully");
                drug_ID.Text = ""; drug_name.Text = ""; expire_date.Text = ""; buy_price.Text = ""; sell_price.Text = ""; quantity.Text = ""; drug_type.Text = "";
                load();
                drug_name.IsEnabled = false; expire_date.IsEnabled = false; buy_price.IsEnabled = false; sell_price.IsEnabled = false; drug_type.IsEnabled = false;
                quantity.IsEnabled = false;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void drug_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            drug_name.IsEnabled = true;
        }

        private void drug_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            expire_date.IsEnabled = true;
        }

        private void expire_date_TextChanged(object sender, TextChangedEventArgs e)
        {
            buy_price.IsEnabled = true;
        }

        private void buy_price_TextChanged(object sender, TextChangedEventArgs e)
        {
            sell_price.IsEnabled = true;
        }

        private void sell_price_TextChanged(object sender, TextChangedEventArgs e)
        {
            quantity.IsEnabled = true;
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = "insert into hopedatabase.drug (`drug_ID`, `drug_name`, `expire_date`, `buy_price`, `sell_price`, `quantity`, `drug_type`) values('" + drug_ID.Text + "','" + drug_name.Text + "','" + expire_date.Text + "','" + buy_price.Text + "','" + sell_price.Text + "','" + quantity.Text + "','" + drug_type.Text + "');";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();

                MessageBox.Show("New drug Registered");
                drug_ID.Text = ""; drug_name.Text = ""; expire_date.Text = ""; buy_price.Text = ""; sell_price.Text = ""; quantity.Text = ""; drug_type.Text = "";
                load();
                drug_name.IsEnabled = false; expire_date.IsEnabled = false; buy_price.IsEnabled = false; sell_price.IsEnabled = false; drug_type.IsEnabled = false;
                quantity.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            drug_type.IsEnabled = true;
        }
    }
}