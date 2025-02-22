using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.QuartzConcurrency
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                StdSchedulerFactory factory = new StdSchedulerFactory();

                IScheduler Scheduler = await factory.GetScheduler();

                IJobDetail job1 = JobBuilder.Create(typeof(JobWithConcurrency)).WithIdentity(typeof(JobWithConcurrency).FullName).WithDescription(typeof(JobWithConcurrency).Name).Build();
                List<ITrigger> triggerOfJob1 = new List<ITrigger>
                {
                    TriggerBuilder.Create()
                    .WithIdentity($"{typeof(JobWithConcurrency).FullName}.trigger0")
                    .WithCronSchedule(JobWithConcurrency.Expressions[0])
                    .WithDescription(JobWithConcurrency.Expressions[0])
                    .Build()
                };

                await Scheduler.ScheduleJob(job1, triggerOfJob1, false);

                IJobDetail job2 = JobBuilder.Create(typeof(JobWithoutConcurrency)).WithIdentity(typeof(JobWithoutConcurrency).FullName).WithDescription(typeof(JobWithoutConcurrency).Name).Build();
                List<ITrigger> triggerOfJob2 = new List<ITrigger>
                {
                    TriggerBuilder.Create()
                    .WithIdentity($"{typeof(JobWithoutConcurrency).FullName}.trigger0")
                    .WithCronSchedule(JobWithoutConcurrency.Expressions[0])
                    .WithDescription(JobWithoutConcurrency.Expressions[0])
                    .Build()
                };

                await Scheduler.ScheduleJob(job2, triggerOfJob2, false);

                await Scheduler.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (1 == 1)
            {
                await Task.Delay(1000);
            }
        }
    }
}
