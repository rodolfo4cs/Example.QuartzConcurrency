using Quartz;
using System.Threading.Tasks;

namespace Example.QuartzConcurrency
{
    [DisallowConcurrentExecution]
    public abstract class AJobWithoutConcurrency : IJob
    {
        public abstract Task Execute(IJobExecutionContext context);
    }
}
