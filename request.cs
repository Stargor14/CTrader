using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
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
    public static class Keys
    {
        public static string publicKey;
        public static string privateKey;
    }
    class request
    {
        public static void JsonLoader()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\starg\source\repos\Stargor14\trader\trader\keys.json"))
            {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                Keys.publicKey = array["public"];
                Keys.privateKey = array["private"];
            }
        }
        public static List<double> Request(string pair)
        {
            JsonLoader();
            var client = new BinanceClient(new BinanceClientOptions
            {
                ApiCredentials = new ApiCredentials(Keys.publicKey, Keys.privateKey)
            });
            List<double> data = new List<double>();
            foreach (var k in client.FuturesUsdt.Market.GetKlines(pair, KlineInterval.FifteenMinutes).Data)
            {
                data.Add(Convert.ToDouble(k.Close));
            }
            return data;
        }
    }
}
