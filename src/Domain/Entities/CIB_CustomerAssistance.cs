using CleanApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Domain.Entities
{
    public class CIB_CustomerAssistance : BaseEntity
    {
        public long UserID { get; set; }
        public string NumberForCallBack { get; set; }
        public string TypeOfAssistance { get; set; }
        public string PlaceOfAssistance { get; set; }
        public string AckOfUserForCall { get; set; }
        public string RedialAssist { get; set; }
        public string CurrentLocation { get; set; }
        public string AdditionalAssistData { get; set; }
        public string LoggedInDevice { get; set; }
        public string SystemKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
