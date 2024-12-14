using CreditSuisse.Models;

namespace CreditSuisse.Interface
{
    public interface IRuleTrade
    {
        bool Apply(Trade trade, DateTime date);
    }
}