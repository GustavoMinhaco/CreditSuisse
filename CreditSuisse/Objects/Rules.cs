using CreditSuisse.Constant;
using CreditSuisse.Interface;
using CreditSuisse.Models;

namespace CreditSuisse.Objects
{
    // RULES TO BE APPLIED BY THE STRATEGY DESIGN PATTERN
    public class EXPIRED : IRuleTrade
    {
        public bool Apply(Trade trade, DateTime date)
        {
            return trade.NextPaymentDate.AddDays(30) < date;
        }
    }

    public class HIGHRISK : IRuleTrade
    {
        public bool Apply(Trade trade, DateTime date)
        {
            return ((trade.Value > MaxTradeValues.MAX_TRADE_VALUE) && (trade.ClientSector.Equals("Private")));
        }
    }

    public class MEDIUMRISK : IRuleTrade
    {
        public bool Apply(Trade trade, DateTime date)
        {
            return ((trade.Value > MaxTradeValues.MAX_TRADE_VALUE) && (trade.ClientSector.Equals("Public")));
        }
    }

}
