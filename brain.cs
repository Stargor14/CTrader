using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
using TicTacTec;

namespace trader
{
    public static class Prices
    {
        public static List<double> prices = new List<double>();
    }
    enum Coins
    {
        BNB,
        UNI,
        ADA,
        LINK,
        XLM,
        XRP,
        EOS,
        LTC,
        BCH,
        ETH,
        BTC
    }
    class brain
    {
        static void Main()
        {
            Console.Title = "Paper Trader!";
            Console.WindowWidth = 28;
            Live();    
        }
        static void Live()
        { 
            technicals tech = new technicals();
            broker broker = new broker();
            analysis anal = new analysis();
            //while (true)
            {
                Prices.prices = request.Request("BNBUSDT");
                int type = anal.Check(tech.STOCHRSI(), tech.STOCHRSI());
                if (type == 1)
                {
                    if (broker.init == true)
                    {
                        broker.init = false;
                        broker.inLong = true;
                        Console.WriteLine("READY TO SHORT ON CROSS");
                    }
                    else if (broker.inLong == false )
                    {
                        if (broker.inShort == true)
                        {
                            broker.Close();
                            broker.inShort = false;
                            broker.Long();
                            broker.inLong = true;
                        }      
                    }
                }
                if (type == 2)
                {
                    if (broker.init == true)
                    {
                        broker.init = false;
                        broker.inShort = true;
                        Console.WriteLine("READY TO LONG ON CROSS");
                    }
                    else if (broker.inShort == false)
                    {
                        if (broker.inLong == true)
                        {
                            broker.Close();
                            broker.inLong = false;
                            broker.Short();
                            broker.inShort = true;
                        }        
                    }
                }
                Thread.Sleep(2000);
                Console.ReadLine();
            }     
        }
    }
}

