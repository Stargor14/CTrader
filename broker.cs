using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Newtonsoft.Json;
using System.IO;

namespace trader
{
    public class brokerpaper
    {
        public bool inShort = false;
        public bool inLong = false;
        public bool init = true;
        public double entry;
        public int coin;
        public double balance = 100;
        public void Long()
        {
            //Long
            entry = Prices.prices[Prices.prices.Count - 1];
        }
        public void Short()
        {
            //Short
            entry = Prices.prices[Prices.prices.Count - 1];
        }
        public void Close()
        {
            //Close
            double exit = Prices.prices[Prices.prices.Count - 1];
            if (inShort == true)
            {
                balance *= entry / exit - .0008;
            }
            if (inLong == true)
            {
                balance *= exit / entry - .0008;
            }
            Console.WriteLine("Closed at {0} new balance: {1}", Prices.prices[Prices.prices.Count - 1], balance);
        }
    }
    public class broker
    {
        public bool inShort = false;
        public bool inLong = false;
        public bool init = true;
        public int coin;
        public double entry;
        public double exit;
        public double balance = 100;
        public void Long()
        {
            entry = Prices.prices[Prices.prices.Count-1];
            Console.WriteLine("Opened Long @ {0}", Prices.prices[Prices.prices.Count - 1]);
        }
        public void Short()
        {
            entry = Prices.prices[Prices.prices.Count - 1];
            Console.WriteLine("Opened Short @ {0}", Prices.prices[Prices.prices.Count - 1]);
        }
        public void Close()
        {
            exit = Prices.prices[Prices.prices.Count - 1];
            //Close
            if (inLong == true)
            {   
                Console.WriteLine("CLOSED LONG @ {0}", Prices.prices[Prices.prices.Count - 1]);
            }
            
            if (inShort == true)
            {            
                Console.WriteLine("CLOSED SHORT @ {0}", Prices.prices[Prices.prices.Count - 1]);
            }
        }
    }
}
