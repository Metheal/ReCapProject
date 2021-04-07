using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDetailDto : IDto
    {
        public int PaymentID { get; set; }
        public int RentalID { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public int CustomerID { get; set; }
    }
}
