using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment: IEntity
    {
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaidAmount { get; set; }
    }
}
