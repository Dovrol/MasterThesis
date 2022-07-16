using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Performance
{
    public static class PerformanceService
    {
        public static async Task<PerformanceResult> MesureTimeElapsed(Func<Task> action)
        {
            Stopwatch stopwatch = new Stopwatch();
                                
            stopwatch.Start();
            await action();
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            return new PerformanceResult {
                Hours = ts.Hours,
                Minutes = ts.Minutes,
                Seconds = ts.Seconds,
                Miliseconds = ts.Milliseconds    
            };
        }
    }
}