using CreditSuisse.Interface;

namespace CreditSuisse.Models
{
    public class Trade : ITrade
    {
        private double _Value;
        public double Value
        {
            get => _Value;
            set => _Value = value;
        }

        private string _ClientSector;
        public string ClientSector
        {
            get => _ClientSector;
            set => _ClientSector = value;
        }

        private DateTime _NextPaymentDate;
        public DateTime NextPaymentDate
        {
            get => _NextPaymentDate;
            set => _NextPaymentDate = value;
        }


        public Trade(){ }
    }
}
