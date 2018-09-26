using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CentralLogProvider;

namespace CentralLogTester {

    class MyService {
        readonly ILogger<MyService> logger;
        public MyService(ILogger<MyService> logger) {
            this.logger = logger;
        }

        public void Start() {
            logger.LogInformation("Initialize test app");
            logger.LogError("This is error");
            logger.LogTrace("This is critical");
        }
    }

    class Program {
        static void Main(string[] args) {
            var url = args[0];

            var collection = new ServiceCollection();
            collection.AddLogging(builder => {
                builder.AddConsole();
                builder.AddCentralLog(new CentralLogOptions(url));
            });

            collection.AddSingleton<MyService>();
            var provider = collection.BuildServiceProvider();
            var service = provider.GetService<MyService>();
            service.Start();

            Console.Read();
        }
    }
}
