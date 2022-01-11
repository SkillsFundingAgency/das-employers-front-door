﻿using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.Serialization;
using Cronos;

namespace SFA.DAS.FindEmploymentSchemes.Web.BackgroundServices
{
    [Serializable]
    public class ContentUpdateServiceException : Exception
    {
        public ContentUpdateServiceException()
        {
        }

        protected ContentUpdateServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ContentUpdateServiceException(string? message) : base(message)
        {
        }

        public ContentUpdateServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Updates content on a schedule, given in a configurable cron expression.
    /// It uses a cron expression, as it's standard, well understood, supported by libraries and provides flexibility,
    /// but also because we want all instances of the app services to update as one,
    /// so the site isn't serving different versions of the content, depending on the instance that happens to service the request.
    /// </summary>
    public class ContentUpdateService : IHostedService, IDisposable
    {
        private int _executionCount;
        private readonly ILogger<ContentUpdateService> _logger;
        private Timer? _timer;
        private readonly CronExpression _cronExpression;

        public ContentUpdateService(ILogger<ContentUpdateService> logger)
        {
            _logger = logger;
            //todo: from config
            //todo: do we want to support changing config without an app service restart?
            _cronExpression = CronExpression.Parse("* * * * *");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Content Update Service running.");

            var delay = TimeToNextInvocation();

            _timer = new Timer(UpdateContent, null, delay, Timeout.InfiniteTimeSpan);

            return Task.CompletedTask;
        }

        private TimeSpan TimeToNextInvocation()
        {
            var now = DateTime.UtcNow;
            DateTime? next = _cronExpression.GetNextOccurrence(now);
            if (next == null)
                throw new ContentUpdateServiceException("Next invocation time is unreachable.");

            return next.Value - now;
        }

        private void UpdateContent(object? state)
        {
            var count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("Content Update Service is updating content. Count: {Count}", count);

            var delay = TimeToNextInvocation();

            //todo: check timer null & throw ex?
            _timer!.Change(delay, Timeout.InfiniteTimeSpan);

            Interlocked.Decrement(ref _executionCount);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Content Update is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _timer?.Dispose();
        }
    }
}
