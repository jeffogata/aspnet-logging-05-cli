namespace aspnet_logging_05_cli
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Logging;

    public class MyLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _path;

        public MyLogger(string categoryName, string basePath)
        {
            _path = Path.Combine(basePath, "mylog.txt");
            _categoryName = categoryName;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception,
            Func<object, Exception, string> formatter)
        {
            using (var writer = File.AppendText(_path))
            {
                writer.WriteLine($"{logLevel} :: {_categoryName} :: {formatter(state, exception)}");
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return new NoopDisposable();
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}