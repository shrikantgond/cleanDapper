using AutoMapper;
using CleanApp.Application.Common.Interfaces;
using CleanApp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApp.Application.Assistance.Queries
{
    public class GetTicketDetailsByIDQuery : IRequest<TicketDetailsDTO>
    {
        public long TicketID { get; set; }

        public class RegisterCommandHandler : IRequestHandler<GetTicketDetailsByIDQuery, TicketDetailsDTO>
        {
            private readonly IADODBContext<CIB_TicketDeatils> _context;
            private readonly IMapper _mapper;

            public RegisterCommandHandler(IADODBContext<CIB_TicketDeatils> context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TicketDetailsDTO> Handle(GetTicketDetailsByIDQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.GetByIDAsync(request.TicketID);
                return _mapper.Map<TicketDetailsDTO>(result);
            }
        }
    }
}
