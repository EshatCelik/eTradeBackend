using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Configurations
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<ActionDto> Actions { get; set; }
    }
}
