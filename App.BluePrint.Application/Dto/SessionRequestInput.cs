using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Dto
{
    public class SessionRequestInput : IInputDto
    {
        public int TenencyId { get; set; }
        public int UserId { get; set; }
    }
}
