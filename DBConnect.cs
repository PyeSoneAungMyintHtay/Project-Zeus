using MySql.Data.MySqlClient;
using System;

namespace single_user_Zeus
{
    internal class  DBConnect
    {
        //public static bool connectiontest;
        public static MySqlConnection connectToDb()
        {
            string connetionString = null;
            MySqlConnection cnn;
            //connetionString = "server=localhost;database=phpmyadmin;uid=root;pwd=;";
            connetionString = "server=localhost;database=hopedatabase;uid=hope;pwd=dsPIC30F4013;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();

                return cnn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}