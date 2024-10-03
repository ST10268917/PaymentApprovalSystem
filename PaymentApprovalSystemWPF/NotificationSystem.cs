using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApprovalSystemWPF
{
    public class NotificationService
    {
        public void NotifyEmployee(string employeeEmail, string message)
        {
            // Simulate sending an email
            Console.WriteLine($"Notification sent to {employeeEmail}: {message}");
        }

        public void NotifyApprover(string approverEmail, string message)
        {
            // Simulate sending an email
            Console.WriteLine($"Notification sent to {approverEmail}: {message}");
        }
    }

}
