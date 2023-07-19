using Castle.DynamicProxy;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Logging;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Logging.Log4Net;
using LayerTemplateEdited.Core.Utilities.Interceptors;
using LayerTemplateEdited.Core.Utilities.IoC;
using LayerTemplateEdited.Core.Utilities.Messages;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace LayerTemplateEdited.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        private LoggerServiceBase _loggerServiceBase;

        public PerformanceAspect(int interval,Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                LogDetailWithPerformance logDetailWithPerformance = GetLogDetail(invocation, _stopwatch.Elapsed.TotalSeconds);
                _loggerServiceBase.Warn(logDetailWithPerformance);

                //Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }

        private LogDetailWithPerformance GetLogDetail(IInvocation invocation , double TotalSeconds)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var LogDetailWithPerformance = new LogDetailWithPerformance
            {
                MethodName = $"{invocation.TargetType.Name}.{invocation.Method.Name}",
                LogParameters = logParameters,
                ElapsedTime = TotalSeconds,
            };

            return LogDetailWithPerformance;
        }
    }
}
