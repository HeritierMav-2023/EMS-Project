using AutoMapper;
using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Domain.Entities;
using CleanArchEMS.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.QueriesStudents.GetStudentById
{
    public record GetStudentByIdQuery : IRequest<Result<GetStudentByIdDto>>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<GetStudentByIdDto>>
    {
        #region Reference object
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor DI
        public GetStudentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Ovveride Methods
        public async Task<Result<GetStudentByIdDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            var student = _mapper.Map<GetStudentByIdDto>(entity);
            return await Result<GetStudentByIdDto>.SuccessAsync(student);
        }
        #endregion
    }
}
