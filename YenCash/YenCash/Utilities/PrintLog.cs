using System;

using Xamarin.Forms;

namespace YenCash
{
    public static class PrintLog
    {
        public static void PublishLog(Exception ex)
        {
            var msg = "";
            try
            {
                msg = ex.Message + "\n" + ex.StackTrace;
            }
            catch(Exception exx)
            {
                msg = "Error in ExceptionPage: \n" + exx.Message + "\n" + exx.StackTrace;
            }
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}

