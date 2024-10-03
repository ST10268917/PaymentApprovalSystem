using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApprovalSystemWPF
{
    public class ApprovalHistory
    {
        public string Approver { get; set; }
        public DateTime ActionDate { get; set; }
        public RequestStatus Status { get; set; }

        public ApprovalHistory(string approver, DateTime actionDate, RequestStatus status)
        {
            Approver = approver;
            ActionDate = actionDate;
            Status = status;
        }
    }
}
