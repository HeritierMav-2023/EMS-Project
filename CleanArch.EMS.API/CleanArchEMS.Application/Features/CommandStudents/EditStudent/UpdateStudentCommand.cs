using AutoMapper;
using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Domain.Entities;
using CleanArchEMS.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchEMS.Application.Features.CommandStudents.EditStudent
{
    record class UpdateStudentCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }

    internal class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<int>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            if (student != null)
            {
                student.Name = request.Name;
                student.Gender = request.Gender;
                student.Address = request.Address;
                student.ContactNumber = request.ContactNumber;

                await _unitOfWork.Repository<Student>().UpdateAsync(student);
                student.AddDomainEvent(new StudentUpdatedEvent(student));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(student.Id, "Student Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Student Not Found.");
            }
        }
    }
}
