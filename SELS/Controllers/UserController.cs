using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SELS_Models;

namespace SELS.Controllers
{
    public class UserController : ApiController
    {
        private const string cCLASS_NAME = "UserController";
        #region
        /// <summary>
        /// To add new User in data base 
        /// </summary>
        /// <param name="pUser">User object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/user/signup")]
        public string SignUp (User pUser)
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

        [HttpGet]
        [Route("api/user/signin")]
        public string SignIn(string pUserName,string pPassword)
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
        #endregion

    }
}
