namespace TicketSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using TicketSystem.Web.Services;
    using TicketSystem.WebApi.Domain;

    public class ProjectsController : Controller
    {
        private readonly ProjectService projectService;
        private readonly TicketService ticketService;

        public ProjectsController(ProjectService projectService,
            TicketService ticketService)
        {
            this.projectService = projectService;
            this.ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = this.projectService.GetAllProjects();

            return Json(projects);
        }

        [HttpGet]
        public IActionResult Tickets(int id)
        {
            var tickets = this.ticketService.GetAllTickets(id);

            return Json(tickets);
        }

        [HttpPost]
        public IActionResult Tickets(int id, TicketViewModel ticketViewModel)
        {
            this.ticketService.CreateNewTicket(id, ticketViewModel);
            return Json(Ok());
        }
    }
}
