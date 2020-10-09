using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Assistance.Commands.RequestAssistance
{
    class RequestAssistanceCommandValidator : AbstractValidator<RequestAssistanceCommand>
    {
        public RequestAssistanceCommandValidator()
        {
            RuleFor(v => v.CurrentLocation)
                .NotEmpty()
                ;
            RuleFor(v => v.LoggedInDevice)
                .NotEmpty()
                ;
            RuleFor(v => v.SystemKey)
                .NotEmpty()
                ;
            RuleFor(v => v.TypeOfAssistance)
                .NotEmpty()
                ;
        }
    }
}
