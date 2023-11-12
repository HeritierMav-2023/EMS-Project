using CleanArchEMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Domain.Entities
{
    public class Student : BaseAuditableEntity
    {
        public Student()
        {
              IssueingDetails = new List<IssuieingBook>();
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        //Relation one to one 
        public int FacultyID { get; set; }
        public Faculty Faculties { get; set; }

        //many
        public IList<IssuieingBook> IssueingDetails { get; set; }
    }
}
