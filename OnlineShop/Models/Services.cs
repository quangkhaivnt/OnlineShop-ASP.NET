using OnlineShop.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Services
    {
        BankServicesClient client = new BankServicesClient();

        List<Partner> listpartner = new List<Partner>();

        public bool LoginPartner(Partner partner)
        {
            var partnerNew = new ServiceReference1.Partner()
            {
                PartnerAccount = partner.PartnerAccount,
                Password = partner.Password
            };
            if (client.LoginPartnerAccount(partnerNew))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transaction(Transaction transaction)
        {
            var transactionNew = new ServiceReference1.Transaction()
            {
                Name = transaction.Name,
                Amount = transaction.Amount,
                Content = transaction.Content,
                SenderAccountNumber = transaction.SenderAccountNumber,
                ReceiverAccountNumber = transaction.ReceiverAccountNumber,
                BillId = transaction.BillId,
                Status = transaction.Status,
                Type = transaction.Type,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt
            };
            if (client.AddTransaction(transactionNew))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Partner Find(long id)
        {
            var find = client.GetPartnerById(id);
            Partner partner = new Partner();
            partner.AccountNumber = Convert.ToInt64(find.AccountNumber);
            return partner;
        }
    }
}