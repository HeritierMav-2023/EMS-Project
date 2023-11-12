using CleanArchEMS.Application.Common.Mappings;
using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.QueriesStudents.GetAllStudents
{
    public class GetAllStudentsDto : IMapFrom<Student>
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int FacultyID { get; set; }
        public Faculty Faculties { get; set; }
    }
}
