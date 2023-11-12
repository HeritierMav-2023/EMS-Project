using CleanArchEMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsByFacAsync(int facId);
        Task<List<Student>> GetAllStudentsAsync();
    }
}
