using System.Globalization;
using CreditSuisse.Constant;
using CreditSuisse.Interface;
using CreditSuisse.Models;

namespace CreditSuisse.Controller
{
    public class OperationController(List<IRuleTrade> rules)
    {
        private readonly List<IRuleTrade> rules = rules;

        public Trade AddTrade(string row)
        {
            string[] words;
            words = row.Split(ConstUtils.DELIMITER);
            Trade trade = new();
            for (int i = 0; i < words.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        trade.Value = Convert.ToDouble(words[i]);
                        break;
                    case 1:
                        trade.ClientSector = words[i];
                        break;
                    case 2:
                        trade.NextPaymentDate = DateTime.ParseExact(words[i], "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                        break;
                }
            }

            return trade;
        }

        public void CategorizeTrades(DateTime dataReference, List<Trade> listTrades)
        {
            foreach (Trade trade in listTrades)
            {
                Console.WriteLine(Categorize(trade, dataReference));
            }
        }

        // apply rules
        public String Categorize(Trade trade, DateTime date)
        {
            foreach (var rule in rules)
            {
                if (rule.Apply(trade, date))
                {
                    return rule.GetType().Name;
                }
            }
            return "NOTCATEGORIZED";
        }
    }
}
