using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SELS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SELS.Controllers
{
    public class CategoryPerUserController : ApiController
    {
        private const string cCLASS_NAME = "CategoryPerUserController";

        [HttpPost]
        public string Post(JObject CategoryPerUser)
        {
            try
            {
                eResult tResult = eResult.Error; 
                CategoryPerUser tCategoryPerUser = JsonConvert.DeserializeObject<CategoryPerUser>(CategoryPerUser.ToString());
                tResult =  Manager_BL.CategoryImplementation.InsertCategroiesPerUser(tCategoryPerUser);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
    }
}
