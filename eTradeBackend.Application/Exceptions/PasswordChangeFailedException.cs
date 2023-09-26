using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Exceptions
{
    public class PasswordChangeFailedException : Exception
    {
        public PasswordChangeFailedException() : base("Şifre güncellenirken bir hata oluştur")
        {

        }
        public PasswordChangeFailedException(string message) : base(message) { }

        public PasswordChangeFailedException(string message, Exception? exception) : base(message, exception) { }
    }
}
