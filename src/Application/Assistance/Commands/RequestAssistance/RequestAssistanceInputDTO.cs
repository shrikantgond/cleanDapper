using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Assistance.Commands.RequestAssistance
{
    public class RequestAssistanceInputDTO
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
    }
}
