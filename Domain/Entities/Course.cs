using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!; // único
        public string Name { get; set; } = default!;
        public int Credits { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = default!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
