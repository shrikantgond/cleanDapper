using AutoMapper;
using CleanApp.Application.Common.Interfaces;
using CleanApp.Application.Common.Mappings;
using CleanApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApp.Application.Authentication.Commands
{
    public class RegisterCommand : RegisterInputDTO, IRequest<long> , IMapFrom<CIB_UserLogin>
    {

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, long>
        {
            private readonly IADODBContext<CIB_UserLogin> _context;
            private readonly IADODBContext<RegisterInputDTO> _contextSP;
            private readonly IMapper _mapper;

            public RegisterCommandHandler(IADODBContext<CIB_UserLogin> context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<long> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var entity = new CIB_UserLogin()
                {
                    CreatedDate = DateTime.Now,
                    EmailAddress = request.EmailAddress,
                    IsActive = true,
                    LoggedInDevice = request.LoggedInDevice,
                    Name = request.Name,
                    Password = request.Password,
                    RegisteredNumber = request.RegisteredNumber,
                    UserName = request.UserName
                };

                return await _context.AddAsync(entity);

            }
        }
    }
}

