using CleanArchEMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Domain.Entities
{
    public class Book : BaseAuditableEntity
    {
        public Book()
        {
              BookDetails = new List<IssuieingBook>();
        }
        public string Title { get; set; }
        public int? FacultyID { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public int NumOfPage { get; set; }
        //Relation one to one 
        public Faculty Faculties { get; set; }

        //
       public List<IssuieingBook> BookDetails { get; set; } 
    }
}
