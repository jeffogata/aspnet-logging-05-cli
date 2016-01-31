namespace aspnet_logging_05_cli
{
    using Microsoft.Extensions.Logging;

    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly string _basePath;

        public MyLoggerProvider(string basePath)
        {
            _basePath = basePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger(categoryName, _basePath);
        }

        public void Dispose()
        {
        }
    }
}