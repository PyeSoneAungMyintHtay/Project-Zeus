using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for patientTreatment.xaml
    /// </summary>
    public partial class patientTreatment : Page
    {
        string selected_id, treatment_id;
        bool flag;
        public patientTreatment()
        {
            InitializeComponent();
            load();
            load_patient();
            load_treatment();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void clear_data()
        {
            patient_contact_no.Text = "";
            patient_age.Text = "";
            patient_bloodgroup.Text = "";
            patient_address.Text = "";
            time_of_admission.Text = "";
            patient_sex.Text = "";
            referred_by.Text = "";
            patient_occupation.Text = "";
            Add_button.IsEnabled = false;
            Delete_button.IsEnabled = false;
            Update_button.IsEnabled = false;
        }
        public void clear_plan()
        {
            date.Text = "";
            treatment_name.Text = "";
            treatment_start_time.Text = "";
            treatment_approximate_time.Text = "";
            treatment_approximate_cost.Text = "";
            paid_amount.Text = "";

        }

        public void load()
        {

            flag = false;
            try
            {
                string sql = "SELECT * from hopedatabase.patient_plan;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);

                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }

            //conn.Close();
        }


        private void load_patient()
        {
            try
            {
                comboboxpatient_name.Items.Clear();
                string Query = "select patient_name from hopedatabase.patient_data;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboboxpatient_name.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void comboboxpatient_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clear_data();
                string sql = "SELECT patient_contact_no,patient_age,patient_blood_group,patient_address,time_of_admission,patient_sex,referred_by,patient_occupation,patient_id from hopedatabase.patient_data where patient_name='" + comboboxpatient_name.SelectedItem + "';";
                MySqlCommand MyCommand = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    patient_contact_no.Text = MyReader.GetString(0).ToString();
                    patient_age.Text = MyReader.GetString(1).ToString();
                    patient_bloodgroup.Text = MyReader.GetString(2).ToString();
                    patient_address.Text = MyReader.GetString(3).ToString();
                    time_of_admission.Text = MyReader.GetString(4).ToString();
                    patient_sex.Text = MyReader.GetString(5).ToString();
                    referred_by.Text = MyReader.GetString(6).ToString();
                    patient_occupation.Text = MyReader.GetString(7).ToString();
                    selected_id = MyReader.GetString(8).ToString();
                }
                MyReader.Close();



            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            treatment_name.IsEnabled = true;
        }

        private void load_treatment()
        {
            try
            {
                string Query = "select treatment_name from hopedatabase.treatment;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    treatment_name.Items.Add(name);
                }
                MyReader2.Close();
                //connn.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void treatment_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            treatment_start_time.IsEnabled = true;
            treatment_approximate_time.Text = "";
            treatment_approximate_cost.Text = "";
            paid_amount.IsEnabled = true;
            string sql = "SELECT time_require,cost from hopedatabase.treatment where treatment_name='" + treatment_name.SelectedItem + "';";
            MySqlCommand MyCommand = new MySqlCommand(sql, conn);
            MySqlDataReader MyReader;
            MyReader = MyCommand.ExecuteReader();
            while (MyReader.Read())
            {
                treatment_approximate_time.Text = MyReader.GetString(0).ToString();
                treatment_approximate_cost.Text = MyReader.GetString(1).ToString();

            }
            MyReader.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into hopedatabase.patient_plan (`patient_id`, `date`, `treatment_name`,`treatment_start_time`, `treatment_approximate_time`, `treatment_approximate_cost`,`paid_amount`,`patient_name`) values('" + selected_id + "','" + date.Text + "','" + treatment_name.SelectedItem + "','" + treatment_start_time.Text + "','" + treatment_approximate_time.Text + "','" + treatment_approximate_cost.Text + "','" + paid_amount.Text + "','" + comboboxpatient_name.Text + "');";
                MySqlCommand mycommand = new MySqlCommand(query, conn);
                MySqlDataReader myreader;
                myreader = mycommand.ExecuteReader();
                myreader.Close();

                MessageBox.Show("treatment registered");

                clear_data();
                clear_plan();
                load();
                load_patient();
                load_treatment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                comboboxpatient_name.Text = row["patient_name"].ToString();
                date.Text = row["date"].ToString();
                treatment_name.SelectedItem = row["treatment_name"].ToString();
                treatment_start_time.Text = row["treatment_start_time"].ToString();
                treatment_start_time.IsEnabled = true;
                paid_amount.Text = row["paid_amount"].ToString();
                treatment_id = row["treatment_plan_id"].ToString();
                paid_amount.IsEnabled = true;
                Add_button.IsEnabled = false;
                Delete_button.IsEnabled = true;
                Update_button.IsEnabled = true;
                flag = true;

            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hopedatabase.patient_plan set patient_id = '" + selected_id + "', date = '" + date.Text + "', treatment_name = '" + treatment_name.SelectedItem + "', treatment_start_time = '" + treatment_start_time.Text + "', treatment_approximate_time = '" + treatment_approximate_time.Text + "', treatment_approximate_cost = '" + treatment_approximate_cost.Text + "', paid_amount = '" + paid_amount.Text + "', patient_name = '" + comboboxpatient_name.Text + "' where (treatment_plan_id = '" + treatment_id + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show(" Updated Succesfully");

                //patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no2.Text = ""; datepicker.Text = "";
                //referred_by.Text = ""; patient_occupation.Text = "";
                //comboboxBloodGroup.Items.Clear(); comboboxPatient_sex.Items.Clear();
                //load();
                //load_blood_group();
                //load_sex();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void paid_amount_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (flag == false) Add_button.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hopedatabase.patient_plan where treatment_plan_id='" + treatment_id + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Patient Deleted");

                clear_data();
                clear_plan();
                load();
                load_patient();
                load_treatment();

            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}