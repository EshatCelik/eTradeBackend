using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IQRCodeService
    {
        byte[] GetQRCode(string text);
    }
}
