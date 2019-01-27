using Org.Xml.Sax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZPISrokovnik.Utils
{
    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
