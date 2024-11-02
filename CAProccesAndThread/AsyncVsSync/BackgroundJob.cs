using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncVsSync
{
    public class BackgroundJob : BackgroundService
    {
        private readonly ILogger _logger;
        public BackgroundJob(ILogger<BackgroundJob> logger)
        {
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogInformation("background job is start");


            await controller();

            _logger.LogInformation("background job is start");



        }



        static async Task dataBase()
        {

            Console.WriteLine("database task start");

            await Task.Delay(3000);

            Console.WriteLine("database task end");

        }


        static async Task repository()
        {

            Console.WriteLine("repository task  start");
            await dataBase();
            Console.WriteLine("repository task  end");



        }



        static async Task controller()
        {

            Console.WriteLine("controller task  start");

            await repository();
            Console.WriteLine("controller task  end");



        }








    }
}
