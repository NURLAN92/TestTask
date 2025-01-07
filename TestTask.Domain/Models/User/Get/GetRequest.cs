using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Models.User.Get
{
    public class GetRequest
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
