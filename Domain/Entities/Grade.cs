using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Grade
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; } = default!;
        public string Type { get; set; } = "Final"; // Parcial, Taller, Final, etc.
        public decimal Value { get; set; }
        public DateTime GradedAt { get; set; } = DateTime.UtcNow;
    }
}
