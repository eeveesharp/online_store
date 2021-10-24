using Microsoft.Extensions.Configuration;
using OnlineStore.Implementations;
using System;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public class Timer
    {
        public int Step { get; private set; }

        public bool IsStop { get; private set; } = false;

        public int ExpiredTime { get; private set; }

        private readonly IConfiguration _configuration = new ConfigurationBuilder()
                .AddJsonFile(System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName +
            "\\jsonFiles\\timer.json")
                .Build();

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
            File file = new File();

            while (!IsStop)
            {
                Task.Delay(Step).Wait();

                ExpiredTime -= Step;

                if (ExpiredTime < 0)
                {
                    Basket.DeleteProductsByTimer();

                    Console.WriteLine("Basket is empty");

                    IsStop = true;

                    file.ReadProduct("products");
                }
            }
        }
    }
}