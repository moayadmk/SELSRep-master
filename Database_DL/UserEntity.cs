using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SELS_Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Database_DL
{
    public class UserEntity
    {
        private const string cCLASS_NAME = "UserEntity";
        public static eResult SignUp(User pUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"
                                    INSERT INTO dbo.[User] VALUES (
                                    '" + pUser.Username + @"'
                                    ,'" + pUser.Password + @"'
                                    ,'" + pUser.Phonenumber + @"'
                                  )";
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                    tResult = eResult.Sucess;
                }
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }


        public static eResult SignIn(string pUserName, string pPassword)
        {
            try
            {
                eResult tResult = eResult.Error;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT COUNT(*) FROM [user] WHERE [username]='" + pUserName + "' AND [password]='" + pPassword + "'", con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    tResult = eResult.Sucess;
                }
                else
                {
                    tResult = eResult.Error;
                }
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult GetUserByID(string pID, ref User pUser)
        {
            try
            {
                eResult tResult = eResult.NotFound;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [user] WHERE [ID]='" + pID + "'", con);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                pUser = new User();
                foreach (DataRow row in dataTable.Rows)
                {
                    pUser.ID = Convert.ToInt32(row["ID"].ToString());
                    pUser.Username = row["Username"].ToString();
                    pUser.Password = row["Password"].ToString();
                    pUser.Phonenumber = row["Phonenumber"].ToString();
                    tResult = eResult.Sucess;
                }
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult EditUser(User pUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                string tQuery = @"UPDATE dbo.[User] SET Username = '" + pUser.Username + @"', Password = '" + pUser.Password + @"', Phonenumber = '" + pUser.Phonenumber + @"' WHERE ID = " + pUser.ID;
                DataTable tTable = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAppDB"].ConnectionString))
                using (var tCommand = new SqlCommand(tQuery, con))
                using (var tDatatable = new SqlDataAdapter(tCommand))
                {
                    tCommand.CommandType = CommandType.Text;
                    tDatatable.Fill(tTable);
                    tResult = eResult.Sucess;
                }
                return tResult;

            }
            catch (Exception ex)
            {

                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
    }
}
