namespace TicketSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using TicketSystem.Web.Services;

    public class ProjectsController : Controller
    {
        private readonly TicketService ticketService;

        public ProjectsController(TicketService ticketService)
        {
            this.ticketService = ticketService;
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


            return View();
        }


    }
}
