using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.VerifyPasswordResetToken
{
    public class VerifyPasswordResetTokenCommandRequest:IRequest<VerifyPasswordResetTokenCommandResponse>
    {
        public string UserId { get; set; }
        public string  ResetToken { get; set; }

    }

}
