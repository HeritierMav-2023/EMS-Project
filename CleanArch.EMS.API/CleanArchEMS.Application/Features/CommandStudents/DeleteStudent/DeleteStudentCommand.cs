using AutoMapper;
using CleanArchEMS.Application.Common.Mappings;
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

namespace CleanArchEMS.Application.Features.CommandStudents.DeleteStudent
{
    public record DeleteStudentCommand : IRequest<Result<int>>, IMapFrom<Student>
    {
        public int Id { get; set; }

        public DeleteStudentCommand()
        {
        }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }

    internal class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Result<int>>
    {

        #region Object reference
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor DI
        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Ovveride Methods
        public async Task<Result<int>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            if (student != null)
            {
                await _unitOfWork.Repository<Student>().DeleteAsync(student);
                student.AddDomainEvent(new StudentDeletedEvent(student));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(student.Id, "Student Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Student Not Found.");
            }
        }
        #endregion

    }
}
