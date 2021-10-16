using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Shop
{
    public class Timer
    {
        private readonly IConfiguration _configuration = new ConfigurationBuilder()
                .AddJsonFile("timer.json")
                .Build();

        public int Step { get; private set; }

        public bool IsStop { get; private set; } = false;

        public int ExpiredTime { get; private set; }

        public Timer()
        {
            Step = _configuration.GetValue<int>("Step");
            ExpiredTime = _configuration.GetValue<int>("ExpiredTime");
        }

        public void Start()
        {
            if (!IsStop)
            {
                Task task = new Task(Work);
                task.Start();
            }
        }

        private void Work()
        {
            while (!IsStop)
            {
                Task.Delay(Step).Wait();
                ExpiredTime -= Step;

                if (ExpiredTime < 0)
                {
                    Basket.DeleteProductsByTimer();
                    Console.WriteLine("Basket is empty");
                    IsStop = true;
                    File.ReadProduct("products");
                }
            }
        }
    }
}