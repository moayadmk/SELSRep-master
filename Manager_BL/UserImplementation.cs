using System;
using System.Collections.Generic;
using System.Text;
using SELS_Models;

namespace Manager_BL
{
    public class UserImplementation
    {
        private const string cCLASS_NAME = "UserImplementation";
        /// <summary>
        /// To check the validate the username and password
        /// </summary>
        /// <param name="pUser"></param>
        /// <returns></returns>
        private static bool CheckValidateUserNameAndPassword(User pUser)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return false;
            }
        }
        public static eResult SignUp(User pUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                if(CheckValidateUserNameAndPassword(pUser))
                {
                    tResult = Database_DL.UserEntity.SignUp(pUser);
                }
                return tResult;
            }
            catch(Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
            }

        }

        public static eResult SignIn(string pUserName, string pPassword)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.UserEntity.SignIn(pUserName, pPassword);
                return tResult;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
            }
        }
    }
}
