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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView ev = new EmployeeView();
            ev.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<PaymentRequest> requests = new List<PaymentRequest>
    {
        new PaymentRequest("1", 1500, "Travel expenses", DateTime.Now), // Sample data
        new PaymentRequest("2", 500, "Office supplies", DateTime.Now)
    };
            Approver approver = new TeamLead();
            ApproverView av = new ApproverView(approver, requests);
            av.Show();
        }
    }
}
