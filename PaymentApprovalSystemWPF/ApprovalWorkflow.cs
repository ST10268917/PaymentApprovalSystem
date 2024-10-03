using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApprovalSystemWPF
{
    public class ApprovalWorkflow
    {
        public void ProcessRequest(PaymentRequest request, Approver approver)
        {
            if (request.Amount <= approver.ApprovalLimit)
            {
                approver.Approve(request);
            }
            else
            {
                Console.WriteLine("Amount exceeds approval limit.");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ApprovalLimitAttribute : Attribute
    {
        public double MaxAmount { get; }

        public ApprovalLimitAttribute(double maxAmount)
        {
            MaxAmount = maxAmount;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RequiredApprovalAttribute : Attribute
    {
        public string ApproverRole { get; }

        public RequiredApprovalAttribute(string approverRole)
        {
            ApproverRole = approverRole;
        }
    }



}
