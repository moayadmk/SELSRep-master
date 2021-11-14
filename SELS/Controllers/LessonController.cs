using Newtonsoft.Json.Linq;
using SELS_Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SELS.Controllers
{
    public class LessonController : ApiController
    {
        private const string cCLASS_NAME = "LessonController";
        [HttpGet]
        public List<Lesson> Get()
        {
            try
            {
                eResult tResult = eResult.Error;
                List<Lesson> tLessonList = new List<Lesson>();
                tResult = Manager_BL.LessonImplementation.GetLessonList(ref tLessonList);
                if (tResult == eResult.Sucess)
                {
                    return tLessonList;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return null;
            }
        }
        [HttpGet]
        public Lesson Get(int id)
        {
            try
            {
                eResult tResult = eResult.Error;
                Lesson tLesson = new Lesson();
                tLesson.ID = id;
                tResult = Manager_BL.LessonImplementation.GetLesson(ref tLesson);
                if (tResult == eResult.Sucess)
                {
                    return tLesson;
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return null;
            }
        }
        [HttpPost]
        public string Post(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.LessonImplementation.InsertLesson(pLesson);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }

        [HttpPut]
        public string Put(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.LessonImplementation.EditLesson(pLesson);
                return tResult.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Manager_BL.LessonImplementation.DeleteLesson(id);
                if (tResult == eResult.Sucess)
                {
                    return eResult.Sucess.ToString();
                }
                return eResult.Error.ToString();
            }
            catch (Exception ex)
            {
                Logger.Logeer.Write_Log(cCLASS_NAME + " " + ex.Message);
                return eResult.Error.ToString();
            }
        }
    }
}