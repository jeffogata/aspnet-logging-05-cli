namespace aspnet_logging_05_cli
{
    using Microsoft.Extensions.Logging;

    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;

        public MyClass(ILogger<MyClass> logger)
        {
            _logger = logger;
        }

        public void DoSomething(int input)
        {
            _logger.LogDebug("Starting to do something with input: {0}", input);

            if (input >= -1 && input <= 1)
            {
                _logger.LogInformation("Input of {0} is within the optimal range.", input);
            }
            else if (input > 10)
            {
                _logger.LogWarning("Input of {0} is greater than the typical range.", input);
            }
            else if (input < -10)
            {
                _logger.LogError("Input of {0} is less than the typical range.", input);
            }

            _logger.LogDebug("Finished doing something with input: {0}", input);
        }
    }
}