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
using System.Windows.Navigation;
using System.Windows.Shapes;

using TicketSystem.WebApi.Domain;
using TicketSystem.WPF.Flurl;

namespace TicketSystem.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlurlWrapper flurlInstance;
        private IEnumerable<ProjectViewModel> projects;
        private IEnumerable<TicketViewModel> loadedTickets;


        public MainWindow()
        {
            InitializeComponent();

            this.InitializeProjects();
        }

        private async void InitializeProjects()
        {
            this.flurlInstance = new FlurlWrapper();
            this.projects = await flurlInstance.GetAllProjectsAsync();

            foreach (var project in this.projects)
            {
                this.ProjectName.Items.Add("Project: " + project.Name);
            }
        }

        private async void ProjectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            this.loadedTickets = await this.flurlInstance.GetAllTicketsAsync(this.GetCurrentProjectId());

            this.TicketsListBox.Items.Clear();
            foreach (var ticket in this.loadedTickets)
            {
                this.TicketsListBox.Items.Add(ticket.Subject);
            }
        }

        private void TicketsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TicketsListBox.SelectedItem == null)
            {
                return;
            }

            var ticketSubject = this.TicketsListBox.SelectedItem.ToString();
            var ticket = this.loadedTickets.First(x => x.Subject == ticketSubject);

            this.SubjectTextBox.Text = ticket.Subject;
            this.DescriptionTextBlock.Text = ticket.Description;
            this.Assignee.Text = ticket.Assignee.Name;
        }

        private void NewTicketButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.ProjectName.SelectedItem == null)
            {
                MessageBox.Show("First select project!");
                return;
            }

            int currProjId = this.GetCurrentProjectId();
            new CreateNewTicket(currProjId).Show();
        }

        private int GetCurrentProjectId()
        {
            var projectName = this.ProjectName.SelectedItem.ToString().Remove(0, 9);
            var project = this.projects.First(x => x.Name == projectName);

            return project.Id;
        }
    }
}