namespace TicketSystem.Web.Data.Common
{
    using System;

    public interface IBaseModel
    {
        DateTime CreatedOn { get; set; }
    }
}
