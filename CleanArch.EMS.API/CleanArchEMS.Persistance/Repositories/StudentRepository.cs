using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Persistance.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IGenericRepository<Student> _repository;

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _repository.Entities.Include(x=>x.Faculties.Name).ToListAsync();
        }

        public async Task<List<Student>> GetStudentsByFacAsync(int facId)
        {
            return await _repository.Entities.Include(x=>x.FacultyID == facId).ToListAsync();
        }
    }
}
