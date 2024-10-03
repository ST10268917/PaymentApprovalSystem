using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApprovalSystemWPF
{
    public class PaymentRequest
    {
        public string RequestID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public List<ApprovalHistory> History { get; set; }

        public PaymentRequest(string requestId, decimal amount, string description, DateTime requestDate)
        {
            RequestID = requestId;
            Amount = amount;
            Description = description;
            RequestDate = requestDate;
            Status = RequestStatus.Pending;
            History = new List<ApprovalHistory>();
        }
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

}
