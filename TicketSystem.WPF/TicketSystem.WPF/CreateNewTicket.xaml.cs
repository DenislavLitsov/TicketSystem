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
using TicketSystem.WebApi.Domain;

using TicketSystem.WPF.Flurl;

namespace TicketSystem.WPF
{
    /// <summary>
    /// Interaction logic for CreateNewTicket.xaml
    /// </summary>
    public partial class CreateNewTicket : Window
    {
        private readonly Action onClose;
        private readonly int projectId;

        public CreateNewTicket(int projectId, Action onClose)
        {
            this.projectId = projectId;
            this.onClose = onClose;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string subject = this.Subject.Text;
            string description = this.Description.Text;
            string assignee = this.Assignee.Text;

            var ticket = new TicketViewModel()
            {
                Subject = subject,
                Description = description,
                Assignee = new UserViewModel()
                {
                    Name = assignee,
                },
                EstimatedHours = new Random().NextDouble() * 15,
                ProjectId = projectId
            };

            var flurlWrapper = new FlurlWrapper();
            await flurlWrapper.CreateNewTicketAsync(ticket);
            this.onClose();
            this.Close();
        }
    }
}
