using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PaymentApprovalSystemWPF
{
    /// <summary>
    /// Interaction logic for ApproverView.xaml
    /// </summary>
    public partial class ApproverView : Window
    {
        private List<PaymentRequest> pendingRequests;
        private Approver currentApprover;

        public ApproverView(Approver approver, List<PaymentRequest> requests)
        {
            InitializeComponent();
            currentApprover = approver;
            pendingRequests = requests;

            // Display pending requests that the approver can approve
            lstPendingRequests.ItemsSource = pendingRequests;
            lblApproverInfo.Text = $"Logged in as: {currentApprover.GetType().Name} (Approval Limit: {currentApprover.ApprovalLimit})";
        }

        private void ApproveRequest_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected request from the list
            var selectedRequest = lstPendingRequests.SelectedItem as PaymentRequest;
            if (selectedRequest != null)
            {
                // Process approval only if the approver's limit allows it
                if (selectedRequest.Amount <= currentApprover.ApprovalLimit)
                {
                    currentApprover.Approve(selectedRequest);
                    MessageBox.Show($"Request approved by {currentApprover.GetType().Name}!");
                    RefreshRequestList();
                }
                else
                {
                    MessageBox.Show("This request exceeds your approval limit.");
                }
            }
        }

        private void RejectRequest_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected request from the list
            var selectedRequest = lstPendingRequests.SelectedItem as PaymentRequest;
            if (selectedRequest != null)
            {
                currentApprover.Reject(selectedRequest);
                MessageBox.Show($"Request rejected by {currentApprover.GetType().Name}.");
                RefreshRequestList();
            }
        }

        // Refresh the pending request list after approval or rejection
        private void RefreshRequestList()
        {
            lstPendingRequests.ItemsSource = null;
            lstPendingRequests.ItemsSource = pendingRequests.FindAll(req => req.Status == RequestStatus.Pending);
        }
    }
    }
