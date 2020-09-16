using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RetryDurableFunction
{
    public static class ProcessNumbersOrchestrators
    {
        [FunctionName("O_ProcessNumbers")]
        public static async Task<object> ProcessNumbers([OrchestrationTrigger]
        IDurableOrchestrationContext ctx, ILogger log)
        {
            //try
            //{

            CallInfo callinfo = new CallInfo
            {
                Numbers = new[] { "+447712892801", "+447833327059" },
                Attempts = 3
            };

            var test = await ctx.CallActivityAsync<object>("A_DoActivityThreeTimes", callinfo);

            return new
            {
                Success = true
            };

            //}
            //catch (Exception e)
            //{
            //    // Log Exception, pefrom any cleanup
            //    return new
            //    {
            //        Success = false,
            //        Error = e.Message
            //    };
            //}
        }
    }
}
