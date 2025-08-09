﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = default!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
