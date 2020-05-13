using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for RegisterPatientPage.xaml
    /// </summary>
    public partial class RegisterPatientPage : Page
    {
        public RegisterPatientPage()
        {
            InitializeComponent();

            load_patient_id();

            load_blood_group();
            load_sex();
            load();
        }

        public MySqlConnection connn = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT * from hopedatabase.patient_data;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connn);
                da.Fill(ds);

                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
                button.IsEnabled = true;
                button_update.IsEnabled = false;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }

            //connn.Close();
        }

        private void load_patient_id()
        {
            try
            {
                string Query = "select MAX(patient_id) from hopedatabase.patient_data;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, connn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    patient_ID.Text = name;
                }
                MyReader2.Close();
                //connn.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void load_blood_group()
        {
            try
            {
                string Query = "select * from hopedatabase.blood_group;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, connn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboboxBloodGroup.Items.Add(name);
                }
                MyReader2.Close();
                //connn.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        public void load_sex()
        {
            try
            {
                string Query = "select * from hopedatabase.patient_sex;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, connn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboboxPatient_sex.Items.Add(name);
                    //comboboxBloodGroup.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = "insert into hopedatabase.patient_data (`patient_name`, `patient_age`, `patient_contact_no`, `patient_address`, `time_of_admission`, `patient_sex`, `patient_occupation`) values('" + patient_name.Text + "','" + patient_age.Text + "','" + patient_contact_no2.Text + "','" + patient_address.Text + "','" + datepicker.Text + "','" + comboboxPatient_sex.SelectedItem.ToString() + "','" + patient_occupation.Text + "');";
                MySqlCommand MyCommand = new MySqlCommand(Query, connn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();

                MessageBox.Show("Patient Registered");
                string Query1 = "insert into hopedatabase.patient_data ( `patient_blood_group` ) values('" + comboboxBloodGroup.SelectedItem.ToString() + "');";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, connn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                MyReader1.Close();

                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no2.Text = ""; referred_by.Text = ""; datepicker.Text = "";
                patient_occupation.Text = "";
                comboboxBloodGroup.Items.Clear(); comboboxPatient_sex.Items.Clear();

                load_blood_group();

                load();
                patient_name.IsEnabled = false; patient_address.IsEnabled = false; patient_age.IsEnabled = false; referred_by.IsEnabled = false;
                comboboxBloodGroup.IsEnabled = false;
            }
            catch
            {

            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void patient_contact_no2_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_name.IsEnabled = true;
        }

        private void patient_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_age.IsEnabled = true;
        }

        private void patient_age_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboboxBloodGroup.IsEnabled = true;
            patient_address.IsEnabled = true;
        }

        private void comboboxBloodGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient_address.IsEnabled = true;
        }

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                patient_ID.Text = row["patient_id"].ToString();
                patient_name.Text = row["patient_name"].ToString();
                patient_age.Text = row["patient_age"].ToString();
                patient_contact_no2.Text = row["patient_contact_no"].ToString();
                comboboxBloodGroup.SelectedItem = row["patient_blood_group"];
                patient_address.Text = row["patient_address"].ToString();
                datepicker.Text = row["time_of_admission"].ToString();
                comboboxPatient_sex.SelectedItem = row["patient_sex"].ToString();
                referred_by.Text = row["referred_by"].ToString();
                patient_occupation.Text = row["patient_occupation"].ToString();
                button.IsEnabled = false;
                button_update.IsEnabled = true;
            }
            catch { }
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hopedatabase.patient_data where patient_id='" + patient_ID.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, connn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Patient Deleted");
                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no2.Text = ""; referred_by.Text = ""; datepicker.Text = "";
                patient_occupation.Text = "";
                comboboxBloodGroup.Items.Clear();

                load_patient_id();
                load();
                load_blood_group();
                load_sex();
                patient_name.IsEnabled = false; patient_address.IsEnabled = false; patient_age.IsEnabled = false; referred_by.IsEnabled = false; patient_occupation.IsEnabled = false;
                comboboxBloodGroup.IsEnabled = false;
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
                string sql = "update hopedatabase.patient_data set patient_name = '" + patient_name.Text + "', patient_age = '" + patient_age.Text + "', patient_contact_no = '" + patient_contact_no2.Text + "', patient_blood_group = '" + comboboxBloodGroup.SelectedItem.ToString() + "', patient_address = '" + patient_address.Text + "', time_of_admission = '" + datepicker.Text + "', patient_sex = '" + comboboxPatient_sex.SelectedItem.ToString() + "', referred_by = '" + referred_by.Text + "', patient_occupation = '" + patient_occupation.Text + "' where (patient_id = '" + patient_ID.Text + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, connn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show(" Updated Succesfully");

                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no2.Text = ""; datepicker.Text = "";
                referred_by.Text = ""; patient_occupation.Text = "";
                comboboxBloodGroup.Items.Clear(); comboboxPatient_sex.Items.Clear();
                load();
                load_blood_group();
                load_sex();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void comboboxPatient_sex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            referred_by.IsEnabled = true;
        }

        private void referred_by_SelectionChanged(object sender, RoutedEventArgs e)
        {
            patient_occupation.IsEnabled = true;
        }
    }
}