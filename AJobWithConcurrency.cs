using Quartz;
using System.Threading.Tasks;

namespace Example.QuartzConcurrency
{
    public abstract class AJobWithConcurrency : IJob
    {
        public abstract Task Execute(IJobExecutionContext context);
    }
}
