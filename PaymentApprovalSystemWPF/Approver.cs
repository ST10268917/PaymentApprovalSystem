using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApprovalSystemWPF
{
    public abstract class Approver
    {
        public string Name { get; set; }
        public decimal ApprovalLimit { get; set; }
        public abstract void Approve(PaymentRequest request);
        public abstract void Reject(PaymentRequest request);
    }

    [ApprovalLimit(1000)]
    public class TeamLead : Approver
    {
        public override void Approve(PaymentRequest request)
        {
            request.Status = RequestStatus.Approved;
            request.History.Add(new ApprovalHistory("Team Lead", DateTime.Now, RequestStatus.Approved));
        }

        public override void Reject(PaymentRequest request)
        {
            request.Status = RequestStatus.Rejected;
            request.History.Add(new ApprovalHistory("Team Lead", DateTime.Now, RequestStatus.Rejected));
        }
    }

    [ApprovalLimit(10000)]
    public class Manager : Approver
    {
        public override void Approve(PaymentRequest request)
        {
            request.Status = RequestStatus.Approved;
            request.History.Add(new ApprovalHistory("Manager", DateTime.Now, RequestStatus.Approved));
        }

        public override void Reject(PaymentRequest request)
        {
            request.Status = RequestStatus.Rejected;
            request.History.Add(new ApprovalHistory("Manager", DateTime.Now, RequestStatus.Rejected));
        }
    }

    [ApprovalLimit(double.MaxValue)]
    public class Director : Approver
    {
        public override void Approve(PaymentRequest request)
        {
            request.Status = RequestStatus.Approved;
            request.History.Add(new ApprovalHistory("Director", DateTime.Now, RequestStatus.Approved));
        }

        public override void Reject(PaymentRequest request)
        {
            request.Status = RequestStatus.Rejected;
            request.History.Add(new ApprovalHistory("Director", DateTime.Now, RequestStatus.Rejected));
        }
    }

}
