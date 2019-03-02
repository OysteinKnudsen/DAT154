using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class Dex
    {
        public static int Day { get; set; } = 1;

        static void Main(String[] args)
        {
            //create stocks 
            Stock hydro, dnb, telenor;

            List<Stock> stocks = new List<Stock>
            {
                (hydro = new Stock("Hydro", 210)),
                (dnb = new Stock("DNB", 310)),
                (telenor = new Stock("Telenor", 410))
            };

            //Creat brokers and Persons
            Person kåre, svein, rich;

            List<Person> traders = new List<Person>
            {
                (kåre = new Broker("Kåre")),
                (svein= new Broker("Svein")),
                (rich= new Broker("Rich")),
            };

            //Subscribe to stocks
            kåre.Subscribe(hydro);
            kåre.Subscribe(dnb);
            svein.Subscribe(telenor);
            rich.Subscribe(hydro);

            //run simulation
            for (; Day < 31; Day++)
            {
                foreach (Stock stock in stocks) {
                    if (stock.CalcNewRate()) Console.ReadKey();
                }
            }

            //Invoice customers
            foreach (Person person in traders) {
                person.Invoice();

                Console.Read();
            }
           
        }

    }
}
