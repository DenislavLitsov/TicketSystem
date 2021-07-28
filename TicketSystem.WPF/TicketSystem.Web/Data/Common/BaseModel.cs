namespace TicketSystem.Web.Data.Common
{
    using System;
    public class BaseModel<TKey> : IBaseModel
    {
        public BaseModel()
        {
        }

        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
