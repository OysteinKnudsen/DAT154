using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    //Definition of delegate
    public delegate void Alarm(Stock s);
   public class Stock
    {
        //Event that will will be fired when 100pt limit is reached.
        public event Alarm LimitReachedEvent;

        private Random rnd = new Random();

        public int Rate { get; set; }
        public string Name { get; set; }

        public Stock(String name, int rate)
        {
            Rate = rate;
            Name = name;
        }

        /// <summary>
        /// Calculates a new rate for the stock object
        /// Fires event if 100pt limit is passed.
        /// </summary>
        /// <returns></returns>
        public bool CalcNewRate()
        {
            int dr = rnd.Next(-35, 45);
            Rate += dr;
            if ((Rate - dr) / 100 != Rate / 100)
            {
                LimitReachedEvent(this);
                return true;
            }
            return false;
        }

    }
}
