using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace RetryDurableFunction
{
    public static class ProcessNumbersActivities
    {
        [FunctionName("A_DoActivityThreeTimes")]
        public static async Task<object> DoActivityThreeTimes([ActivityTrigger] CallInfo callinfo, ILogger log)
        {
            var myCallInfo = callinfo;

            foreach (var number in myCallInfo.Numbers)
            {
                for (int retryCount = 1; retryCount <= myCallInfo.Attempts; retryCount++)
                {

                    log.LogWarning($"The {number} has been called {retryCount} times");
                }
            }

            await Task.Delay(100);

            return "blah";
        }

    }
}
