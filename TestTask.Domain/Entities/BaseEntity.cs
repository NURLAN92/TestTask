using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set;  } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
