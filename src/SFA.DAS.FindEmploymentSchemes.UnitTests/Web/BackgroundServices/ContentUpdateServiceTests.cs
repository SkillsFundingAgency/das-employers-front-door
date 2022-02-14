﻿using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SFA.DAS.FindEmploymentSchemes.Contentful.Services;
using SFA.DAS.FindEmploymentSchemes.Web.BackgroundServices;
using System.Threading.Tasks;
using FakeItEasy;
using Xunit;
using System.Globalization;
using SFA.DAS.FindEmploymentSchemes.Contentful.Exceptions;

namespace SFA.DAS.FindEmploymentSchemes.UnitTests.Web.BackgroundServices
{
    public class ContentUpdateServiceTests
    {
        public ContentUpdateServiceOptions ContentUpdateServiceOptions { get; set; }
        public IOptions<ContentUpdateServiceOptions> ContentUpdateServiceOptionsOptions { get; set; }
        public IContentService ContentService { get; set; }
        public ILogger<ContentUpdateService> Logger { get; set; }

        public ContentUpdateServiceTests()
        {
            ContentUpdateServiceOptions = new ContentUpdateServiceOptions
            {
                Enabled = true,
                CronSchedule = "*/30 * * * *"
            };
            ContentUpdateServiceOptionsOptions = A.Fake<IOptions<ContentUpdateServiceOptions>>();

            A.CallTo(() => ContentUpdateServiceOptionsOptions.Value)
                .Returns(ContentUpdateServiceOptions);
            
            ContentService = A.Fake<IContentService>();
            Logger = A.Fake<ILogger<ContentUpdateService>>();
        }

        [Fact]
        public void Ctor_EmptyCronScheduleConfigTest()
        {
            ContentUpdateServiceOptions.CronSchedule = "";

            Assert.Throws<ConfigurationMissingException>(CreateContentUpdateService);
        }

        [Fact]
        public void Ctor_NullCronScheduleConfigTest()
        {
            ContentUpdateServiceOptions.CronSchedule = null;

            Assert.Throws<ConfigurationMissingException>(CreateContentUpdateService);
        }

        [Fact]
        public async Task StartAsync_NotEnabledDontUpdateTest()
        {
            ContentUpdateServiceOptions.Enabled = false;

            var contentUpdateService = CreateContentUpdateService();

            await contentUpdateService.StartAsync(CancellationToken.None);

            A.CallTo(() => ContentService.Update())
                .MustNotHaveHappened();
        }

        [Theory]
        [InlineData("00:15:00", "*/30 * * * *", "2022-01-31T13:45:00.0000000Z")]
        [InlineData("00:00:30", "0,30 6-23 * * *", "2022-01-31T08:29:30.0000000Z")]
        [InlineData("06:29:00", "0,30 6-23 * * *", "2022-01-31T23:31:00.0000000Z")]
        [InlineData("05:59:00", "0,30 6-23 * * *", "2022-01-31T00:01:00.0000000Z")]
        [InlineData("01:03:00", "3-58/5 8-18 * * *", "2022-01-31T07:00:00.0000000Z")]
        [InlineData("00:04:00", "3-58/5 8-18 * * *", "2022-01-31T08:04:00.0000000Z")]
        public void TimeToNextInvocation_Tests(string expectedDelay, string cronSchedule, string utcNow)
        {
            ContentUpdateServiceOptions.CronSchedule = cronSchedule;
            var contentUpdateService = CreateContentUpdateService();

            CultureInfo provider = CultureInfo.InvariantCulture;
            var utcNowDateTime = DateTime.ParseExact(utcNow, "o", provider).ToUniversalTime();

            var delay = contentUpdateService.TimeToNextInvocation(utcNowDateTime);

            var expectedDelayTimeSpan = TimeSpan.ParseExact(expectedDelay, "c", provider);
            Assert.Equal(expectedDelayTimeSpan, delay);
        }

        private ContentUpdateService CreateContentUpdateService()
        {
            return new ContentUpdateService(ContentUpdateServiceOptionsOptions, ContentService, Logger);
        }
    }
}
