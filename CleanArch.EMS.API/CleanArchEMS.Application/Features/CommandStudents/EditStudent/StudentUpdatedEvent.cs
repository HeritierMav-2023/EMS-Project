using CleanArchEMS.Domain.Common;
using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.CommandStudents.EditStudent
{
    public class StudentUpdatedEvent : BaseEvent
    {
        public Student Student { get; }

        public StudentUpdatedEvent(Student student)
        {
            Student = student;
        }
    }
}
