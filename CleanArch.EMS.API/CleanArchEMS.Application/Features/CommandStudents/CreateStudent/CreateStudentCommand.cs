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

namespace CleanArchEMS.Application.Features.CommandStudents.CreateStudent
{
    /// <summary>
    /// Pour implémenter la fonctionnalité de création de nouveaux Student dans la base de données.
    /// </summary>
    public record CreateStudentCommand : IRequest<Result<int>>, IMapFrom<Student>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

    }

    internal class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<int>>
    {
        #region MyRegion
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor DI
        public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Ovverides Methods
        public async Task<Result<int>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                Name = request.Name,
                Gender = request.Gender,
                Address = request.Address,
                ContactNumber = request.ContactNumber,

            };

            await _unitOfWork.Repository<Student>().AddAsync(student);
            student.AddDomainEvent(new StudentCreatedEvent(student));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(student.Id, "Student Created");

        }
        #endregion
    }
}
