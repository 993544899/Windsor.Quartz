﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Castle.Facilities.Quartz.SampleApp.Listeners
{
    public interface ISampleJobListener : IJobListener
    {

    }
    public class SampleJobListener : ISampleJobListener
    {
        public SampleJobListener()
        {
            Name = GetType().Name;
        }

        public async Task JobToBeExecuted(IJobExecutionContext context,
            CancellationToken token = default(CancellationToken))
        {
            await WriteMesssage("JobToBeExecuted", token);
        }

        public async Task JobExecutionVetoed(IJobExecutionContext context,
            CancellationToken token = default(CancellationToken))
        {
            await WriteMesssage("JobExecutionVetoed", token);
        }

        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException,
            CancellationToken token = default(CancellationToken))
        {
            await WriteMesssage("JobWasExecuted", token);
        }

        public string Name { get; set; }

        private Task WriteMesssage(string message, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() => Console.WriteLine("{0}.{1}", GetType().Name, message), token);
        }
    }
}