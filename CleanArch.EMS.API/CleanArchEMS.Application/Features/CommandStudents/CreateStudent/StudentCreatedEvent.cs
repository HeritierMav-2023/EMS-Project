using CleanArchEMS.Domain.Common;
using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.CommandStudents.CreateStudent
{
    public class StudentCreatedEvent : BaseEvent
    {
        public Student Student { get;}
        public StudentCreatedEvent(Student student) 
        {
           Student = student;   
        }
    }
}
