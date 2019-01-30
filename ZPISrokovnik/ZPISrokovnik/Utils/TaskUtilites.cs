using System;
using System.Threading.Tasks;

namespace ZPISrokovnik.Utils
{
    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Task task)
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
