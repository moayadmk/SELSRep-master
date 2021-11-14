using SELS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_BL
{
    public static class LessonImplementation
    {
        private const string cCLASS_NAME = "LessonImplementation";
        public static eResult GetLessonList(ref List<Lesson> pLessonList)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.LessonEntity.GetLessonList(ref pLessonList);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult GetLesson(ref Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.LessonEntity.GetLesson(ref pLesson);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult DeleteLesson(int pID)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.LessonEntity.DeleteLesson(pID);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult InsertLesson(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.LessonEntity.InsertLesson(pLesson);
                return tResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(cCLASS_NAME + " " + ex.Message);
                return eResult.Error;
            }
        }
        public static eResult EditLesson(Lesson pLesson)
        {
            try
            {
                eResult tResult = eResult.Error;
                tResult = Database_DL.LessonEntity.EditLesson(pLesson);
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
