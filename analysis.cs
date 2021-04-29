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
    class analysis
    {
        public int Check(double K, double D)
        {
            if (K > D && K<20 && D<20)
            {
                return 1;
            }
            else if (K < D && K>80 && D>80)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        //0=none, 1=long/close short, 2=short/close long; will exit earlier this way, return after any kind of signal
    }
}