using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sigma.Core
{
    public class LogUtility
    {
        public static string BuildExceptionMessage(Exception x)
        {
            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            //string errorMsg = Environment.NewLine + "Error in Path :";
            // Get the QueryString along with the Virtual Path
            //errorMsg += Environment.NewLine + "Raw Url :";

            string errorMsg = "";

            // Get the error message
            errorMsg = "Message :" + logException.Message;

            // Source of the message
            errorMsg += Environment.NewLine + "Source :" + logException.Source;

            // Stack Trace of the error
            errorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

            // Method where the error occurred
            errorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;

            return errorMsg;
        }
    }
}