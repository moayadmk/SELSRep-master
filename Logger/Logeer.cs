using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Logeer
    {
        public static void Write_Log(string pMessage)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
