using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];

            for (int i = 1; i < threads.Length; i++)
            {
                threads[i] = new Thread(BankWork);
                threads[i].Start();
            }
            Console.ReadLine();
        }

        static void BankWork()
        {
            User user = new User()
            {
                Money = 5000,
                Name = "Нурсултан"
            };
            Console.WriteLine($"\n {user.Name} баланс: {user.Money}\n Банк ID: {Thread.CurrentThread.ManagedThreadId} начал работу");

            for (int i = 0; i < 5; i++)
            {
                var randNumber = new Random().Next(0, 2);
                var randMoney = new Random().Next(100, 1000);

               
                if (randNumber == 0)
                {

                    user.Money += randMoney;
                    Console.WriteLine($" Пополнение {randMoney} На вашем счету: {user.Money}");
                }
                else if (randNumber == 1)
                {

                    user.Money -= randMoney;
                    Console.WriteLine($" Снятие {randMoney} На вашем счету: {user.Money}");
                }

             
            }
        }
    }

}

