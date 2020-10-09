using CleanApp.Domain.Common;
using System;

namespace CleanApp.Domain.Entities
{
    public class CIB_ServiceProviderDeatils : BaseEntity
    {
        public string Name { get; set; }
        public string TypeOfAssistance { get; set; }
        public TimeSpan StipulatedTimeInMins { get; set; }
        public TimeSpan WorkingFromTime { get; set; }
        public TimeSpan WorkingToTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string Weekends { get; set; }
    }
}
