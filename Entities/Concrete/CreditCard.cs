using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardID { get; set; }
        public string CardHolderName { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CreditCardCVV { get; set; }
        public int CustomerID { get; set; }
    }
}
