using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartVendApp.Helpers
{
    public static class RequestHelper
    {
        public async static Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }
    }
}
