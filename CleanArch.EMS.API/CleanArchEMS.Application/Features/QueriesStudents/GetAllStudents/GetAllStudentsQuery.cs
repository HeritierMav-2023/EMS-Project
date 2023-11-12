using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Domain.Entities;
using CleanArchEMS.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Application.Features.QueriesStudents.GetAllStudents
{
    public record GetAllStudentsQuery : IRequest<Result<List<GetAllStudentsDto>>>;

    internal class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, Result<List<GetAllStudentsDto>>>
    {

        #region Object references 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor DI
        public GetAllStudentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Oveeride Methods
        public async Task<Result<List<GetAllStudentsDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().Entities
                .ProjectTo<GetAllStudentsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllStudentsDto>>.SuccessAsync(student);
        }
        #endregion
    }
}
