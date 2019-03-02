using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    public class Person
    {
        public string name;
        public int price = 10;
        public int amount = 0;

        public Person(string name) { this.name = name; }

        //Subscribe to the event alarm
        public void Subscribe(Stock a)
        {
            a.LimitReachedEvent += new Alarm(Warning);
        }

        //Event handler
        public virtual void Warning(Stock a)
        {
            Console.WriteLine(
                $"Day: " + Dex.Day + 
                "Name: " + name + 
                "Stock: " + a.Name+
                "Rate: " + a.Rate
                );
            amount += price;
        }

        public void Invoice()
        {
            Console.WriteLine("Cust: " + name + " Inv kr : "  + amount);
        }
    }
}
