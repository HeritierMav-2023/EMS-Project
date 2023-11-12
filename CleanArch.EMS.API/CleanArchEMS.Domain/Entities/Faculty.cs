using CleanArchEMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Domain.Entities
{
    public class Faculty : BaseAuditableEntity
    {

        public Faculty()
        {
            Books = new List<Book>();
            Students = new List<Student>();
        }
        public string Name { get; set; }
        //Relation many to many
        public IList<Book> Books { get; set; }
        public IList<Student> Students { get; set; }
    }
}
