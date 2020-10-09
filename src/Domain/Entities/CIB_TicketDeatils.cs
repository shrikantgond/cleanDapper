using CleanApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Domain.Entities
{
    public class CIB_TicketDeatils : BaseEntity
    {
        public long CustomerAssistanceID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string CurrentLocation { get; set; }
        public string TypeOfAssistance { get; set; }
        public string PlaceOfAssistance { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
