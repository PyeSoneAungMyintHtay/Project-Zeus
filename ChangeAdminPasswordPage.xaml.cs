using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for ChangeAdminPasswordPage.xaml
    /// </summary>
    public partial class ChangeAdminPasswordPage : Page
    {
        public ChangeAdminPasswordPage()
        {
            InitializeComponent();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //con.Open();
                if (DocPass.Password.Length == 0 && DocPass2.Password.Length == 0)
                {
                    MessageBox.Show("Null password");
                }
                else if (DocPass.Password == DocPass2.Password)
                {
                    string sql1 = "update hopedatabase.admin set PASSWORD='" + DocPass.Password + "' where NAME='admin';";
                    MySqlCommand MyCommand2 = new MySqlCommand(sql1, con);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    MyReader2.Close();

                    MessageBox.Show("Password Updated Succesfully");
                    DocPass.Clear();
                    DocPass2.Clear();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Passwords does not match");
                }
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}