using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor : BaseEntity
    {
        public int Id { get; set; }
        public string Document { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
