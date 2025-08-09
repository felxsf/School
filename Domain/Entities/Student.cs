using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; } = default!; // único
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
