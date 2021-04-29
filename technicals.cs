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
using TicTacTec;


namespace trader
{
    public class technicals
    {
        public double[] MACD(List<double> prices)
        {

            double[] macd = new double[prices.Count];
            double[] signal = new double[prices.Count];
            double[] macdh = new double[prices.Count];
            int outBegidx;
            int outNbElement;
            TicTacTec.TA.Library.Core.Macd(0, prices.Count - 1, prices.ToArray(), 12,26,9, out outBegidx, out outNbElement, macd,signal,macdh);
            //Console.WriteLine("MACD: {0} SIGNAL: {1}",macd[prices.Count - 35], signal[prices.Count - 35]);
            double[] a = { macd[prices.Count-35], signal[prices.Count-35], macdh[prices.Count-35] };
            return a;
        }
        public double STOCHRSI()
        {
            double[] K = new double[Prices.prices.Count];
            double[] D = new double[Prices.prices.Count];
            int outBegidx;
            int outNbElement;
            TicTacTec.TA.Library.Core.StochRsi(0, Prices.prices.Count - 1, Prices.prices.ToArray(), 14, 3, 3,TicTacTec.TA.Library.Core.MAType.Ema, out outBegidx, out outNbElement, K,D);
            //double[] a = { K[],D[] };
            for(int i = 0; i< Prices.prices.Count-1; i++)
            {
                Console.WriteLine("K: {0} D: {1}",K[i],D[i]);
            }
            return K[0];
        }
    }
}