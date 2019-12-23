﻿using BigBook;
using Spidey.Engines;
using Spidey.Tests.BaseClasses;
using Xunit;

namespace Spidey.Tests.Engines
{
    public class DefaultContentParserTests : TestBaseClass
    {
        [Fact]
        public void Parse()
        {
            var TempData = new UrlData("<html><body>This is a test</body></html>".ToByteArray(),
                "TEXT/HTML",
                "http://google.com/ASDF.html",
                "http://google.com/test.html",
                 333,
                "http://google.com/test.html"
            );
            var TempOptions = new Options
            {
                Allow = { "http://google.com/test.html" },
            };
            var Result = new DefaultContentParser().Parse(TempOptions, TempData);

            Assert.Equal("TEXT/HTML", Result.ContentType);
            Assert.Equal(TempData, Result.Data);
            Assert.Equal("This is a test", Result.FileContent.Content);
            Assert.Equal("http://google.com/ASDF.html", Result.FileName);
            Assert.Equal("http://google.com/test.html", Result.FinalLocation);
            Assert.Equal("http://google.com/test.html", Result.Location);
            Assert.Equal(333, Result.StatusCode);
        }
    }
}