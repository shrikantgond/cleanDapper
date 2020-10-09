using AutoMapper;
using CleanApp.Application.Assistance.Queries;
using CleanApp.Application.Common.Interfaces;
using CleanApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApp.Application.Assistance.Commands.RequestAssistance
{
    public class RequestAssistanceCommand : RequestAssistanceInputDTO,  IRequest<TicketDetailsDTO>
    {

        public class RequestAssistanceCommandHandler : IRequestHandler<RequestAssistanceCommand, TicketDetailsDTO>
        {
            private readonly IADODBContext<CIB_CustomerAssistance> _contextCA;
            private readonly IADODBContext<CIB_TicketDeatils> _contextTKT;
            private readonly IMapper _mapper;

            public RequestAssistanceCommandHandler(IADODBContext<CIB_CustomerAssistance> contextCA, IADODBContext<CIB_TicketDeatils> contextTKT, IMapper mapper)
            {
                _contextCA = contextCA;
                _contextTKT = contextTKT;
                _mapper = mapper;
            }

            public async Task<TicketDetailsDTO> Handle(RequestAssistanceCommand request, CancellationToken cancellationToken)
            {
                //steps
                //step 1 : create Assistance
                CIB_CustomerAssistance customerAssistance = new CIB_CustomerAssistance()
                {
                    AckOfUserForCall = request.AckOfUserForCall,
                    AdditionalAssistData = request.AdditionalAssistData,
                    CreatedDate = DateTime.Now,
                    CurrentLocation = request.CurrentLocation,
                    IsActive = true,
                    LoggedInDevice = request.LoggedInDevice,
                    ModifiedDate = DateTime.Now,
                    NumberForCallBack = request.NumberForCallBack,
                    RedialAssist = request.RedialAssist,
                    SystemKey = request.SystemKey,
                    TypeOfAssistance = request.TypeOfAssistance,
                    PlaceOfAssistance = request.PlaceOfAssistance,
                    UserID = request.UserID
                };

                customerAssistance.CreatedDate = customerAssistance.ModifiedDate = DateTime.Now;
                customerAssistance.IsActive = true;
                var customerAssistanceID = await _contextCA.AddAsync(customerAssistance);

                CIB_TicketDeatils ticketDeatils = null;
                //step 2 : create Ticket
                if (customerAssistanceID > 0)
                {
                    ticketDeatils = new CIB_TicketDeatils()
                    {
                        CreatedDate = DateTime.Now,
                        CurrentLocation = customerAssistance.CurrentLocation,
                        CustomerAssistanceID = customerAssistanceID,
                        IsActive = true,
                        MobileNumber = customerAssistance.NumberForCallBack,
                        Name = customerAssistance.TypeOfAssistance,
                        TypeOfAssistance = customerAssistance.TypeOfAssistance,
                        PlaceOfAssistance = customerAssistance.PlaceOfAssistance

                    };

                    var tktID = await _contextTKT.AddAsync(ticketDeatils);
                    ticketDeatils.ID = tktID;
                }

                return _mapper.Map<TicketDetailsDTO>(ticketDeatils);
            }
        }
    }
}
