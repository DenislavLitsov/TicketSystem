namespace TicketSystem.Data.Common
{
    using System;

    public class BaseModel<TKey>
    {
        public BaseModel()
        {
        }

        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
