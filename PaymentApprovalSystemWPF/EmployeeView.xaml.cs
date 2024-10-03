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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private List<PaymentRequest> paymentRequests;

        public EmployeeView()
        {
            InitializeComponent();
            paymentRequests = new List<PaymentRequest>();
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            // Validate amount and description
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && !string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                // Create a new PaymentRequest object
                var request = new PaymentRequest(Guid.NewGuid().ToString(), amount, txtDescription.Text, DateTime.Now);

                // Add the request to the list
                paymentRequests.Add(request);

                // Refresh the list displayed in the UI
                lstRequests.ItemsSource = null; // Clear the current list
                lstRequests.ItemsSource = paymentRequests; // Bind the updated list

                // Clear the input fields
                txtAmount.Clear();
                txtDescription.Clear();

                MessageBox.Show("Payment request submitted successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a valid amount and description.");
            }
        }
    
}
    }

