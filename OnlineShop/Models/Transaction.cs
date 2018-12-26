using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeTransaction { get; set; }
        public string Content { get; set; }
        public long SenderAccountNumber { get; set; }
        public long ReceiverAccountNumber { get; set; }
        public int Type { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
        public int BillId { get; set; }
    }
}