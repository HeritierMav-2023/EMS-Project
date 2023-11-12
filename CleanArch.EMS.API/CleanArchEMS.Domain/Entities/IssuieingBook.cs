using CleanArchEMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Domain.Entities
{
    public class IssuieingBook : BaseAuditableEntity
    {
        public int SeriaID { get; set; }
        public int? StudentID { get; set; }
        public int? BookID { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReceveid { get; set; }
        public DateTime ActaulReturnDate { get; set; }

        public Student Studient { get; set; }
        public Book _Book { get; set; }
    }
}
