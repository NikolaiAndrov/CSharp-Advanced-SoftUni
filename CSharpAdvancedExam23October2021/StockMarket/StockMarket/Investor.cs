using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new Dictionary<string, Stock>();
        }

        public Dictionary<string, Stock> Portfolio { get; private set; }
        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public decimal MoneyToInvest { get; private set; }
        public string BrokerName { get; private set; }

        public int Count
        {
            get
            {
                return Portfolio.Count;
            }
        }
        
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock.CompanyName, stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < Portfolio[companyName].PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            Portfolio.Remove(companyName);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            if(Portfolio.ContainsKey(companyName))
            {
                return Portfolio[companyName];
            }

            return null ;
        }

        public Stock FindBiggestCompany()
        {
            decimal biggestMarketCapitalization = 0m;
            Stock stock1 = null;

            foreach (var stock in Portfolio)
            {
                if (stock.Value.MarketCapitalization > biggestMarketCapitalization)
                {
                    biggestMarketCapitalization = stock.Value.MarketCapitalization;
                    stock1 = stock.Value;
                }
            }

            return stock1;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
