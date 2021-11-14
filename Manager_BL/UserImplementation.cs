using System;
using System.Collections.Generic;
using System.Text;
using SELS_Models;
using Newtonsoft.Json;

namespace Manager_BL
{
    public class UserImplementation
    {
        private const string cCLASS_NAME = "UserImplementation";
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
        private static eResult GetUserByID(string pID, ref User pUser)
        {
            try
            {
                return Database_DL.UserEntity.GetUserByID(pID, ref pUser);
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
            }
        }
        private static eResult CompareUsers(User pNewUser, User pOldUser)
        {
            try
            {
                string tJSonNewUser = JsonConvert.SerializeObject(pNewUser);
                string tJSonOldUser = JsonConvert.SerializeObject(pOldUser);
                if (tJSonNewUser.Equals(tJSonOldUser))
                {
                    return eResult.Equals;
                }
                return eResult.NotEquals;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
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
        public static eResult IsFilled(FilledTable pFilledTable)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.UserEntity.IsFilled(pFilledTable);
                return tResult;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
            }
        }
        public static eResult EditUser(User pUser)
        {
            try
            {
                User tOldUser = null;
                if (GetUserByID(pUser.ID.ToString(), ref tOldUser) == eResult.Sucess && tOldUser != null)
                {
                    if (eResult.NotEquals == CompareUsers(pUser, tOldUser))
                    {
                        return Database_DL.UserEntity.EditUser(pUser);
                    }
                    return eResult.Equals;
                }
                return eResult.NotFound;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(ex.Message);
                return eResult.Error;
            }
        }
    }
}
