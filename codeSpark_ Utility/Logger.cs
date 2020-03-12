using System;
using System.Collections.Generic;
using System.Text;

namespace codeSpark_Utility
{
    public static class Logger
    {
        // **********************************************************************************************
        // Log
        //
        // Logs passed message in console if enabled_logging = true
        // **********************************************************************************************
        public static void Log(string msg, bool enable_logging = true)
        {
            if (enable_logging)
            {
                Console.WriteLine(@"{0} {1}", DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss"), msg);
            }
        }
    }
}
