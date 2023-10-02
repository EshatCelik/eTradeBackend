using eTradeBackend.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.CustomAttrubute
{
    public class AuthorizeDefinitionAttribute
    {

        public string Menu { get; set; }
        public string Defination { get; set; }
        public ActionType ActionType { get; set; }
    }
}
