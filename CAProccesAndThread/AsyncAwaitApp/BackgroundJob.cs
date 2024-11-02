namespace AsyncAwaitApp
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


            await controller(stoppingToken);

            _logger.LogInformation("background job is start");



        }


        async Task xx()
        {

          await Task.Delay(30000);
            Console.WriteLine("asdasd");
        }


        public async Task dataBase(CancellationToken cancellationToken)
        {

            _logger.LogInformation("dataBase job is start");

             await xx();

            await Task.Delay(30000);

            _logger.LogInformation("dataBase job is start");

        }


        public async Task repository(CancellationToken cancellationToken)
        {

            _logger.LogInformation("repository job is start");
            await dataBase(cancellationToken);
            _logger.LogInformation("repository job is start");



        }



        public async Task controller(CancellationToken cancellationToken)
        {

            _logger.LogInformation("controller job is start");

            await repository(cancellationToken);
            _logger.LogInformation("controller job is start");



        }








    }
}