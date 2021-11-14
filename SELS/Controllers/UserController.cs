using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SELS_Models;

namespace SELS.Controllers
{
    public class UserController : ApiController
    {
        private const string cCLASS_NAME = "UserController";
        #region
        [HttpPost]
        public string Post (User pUser)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.UserImplementation.SignUp(pUser);
                return tResult.ToString();

            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpPut]
        public string Put(User User)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.UserImplementation.EditUser(User);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpGet]
        [Route("api/user/signin")]
        public string SignIn(string pUserName, string pPassword)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.UserImplementation.SignIn(pUserName, pPassword);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpGet]
        [Route("api/user/IsFilled")]
        public FilledTable IsFilled(int pUserId)
        {
            try
            {
                FilledTable pFilledTable = new FilledTable();
                pFilledTable.UserID = pUserId;
                eResult tResult = eResult.Error;
                tResult = Manager_BL.UserImplementation.IsFilled(pFilledTable);
                return pFilledTable;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return null;
            }
        }
        #endregion

    }
}
