using CleanArchEMS.Application.Common.Mappings;
using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.QueriesStudents.GetStudentByFac
{
    public class GetStudentsByFacDto : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        //Relation one to one 
        public int FacultyID { get; set; }
        public Faculty Faculties { get; set; }
    }
}
