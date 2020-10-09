using CleanApp.Application.Common.Mappings;
using System;

namespace CleanApp.Application.Assistance.Queries
{
    public class TicketDetailsDTO : IMapFrom<Domain.Entities.CIB_TicketDeatils>
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string CurrentLocation { get; set; }
        public string TypeOfAssistance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
