using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.QuartzConcurrency
{
    public class JobWithoutConcurrency : AJobWithoutConcurrency
    {
        public override async Task Execute(IJobExecutionContext context)
        {
            var random = new Random().Next(420, 690);
            Console.WriteLine($"        >> START JobWithoutConcurrency {random}");

            //simulate 2min execution
            for (int i = 0; i < 12; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                Console.WriteLine($"        -- {DateTime.Now} JobWithoutConcurrency {random}");
            }

            Console.WriteLine($"        << END JobWithoutConcurrency {random}");
        }

        public static IList<string> Expressions
        {
            get
            {
                return new List<string>
                {
                    "0 0/1 * 1/1 * ? *"
                };
            }
        }
    }
}
