using CleanArchEMS.Domain.Common;
using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.CommandStudents.DeleteStudent
{
    public class StudentDeletedEvent : BaseEvent
    {
        public Student Student { get; }

        public StudentDeletedEvent(Student student)
        {
            Student = student;   
        }
    }
}
