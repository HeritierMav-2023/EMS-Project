using AutoMapper;
using CleanArchEMS.Application.Interfaces.IRepositories;
using CleanArchEMS.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanArchEMS.Application.Features.QueriesStudents.GetStudentByFac
{
    public record GetStudentsByFacQuery : IRequest<Result<List<GetStudentsByFacDto>>>
    {
        public int FacId { get; set; }

        public GetStudentsByFacQuery()
        {
                
        }

        public GetStudentsByFacQuery(int facId)
        {
            FacId = facId;   
        }

        internal class GetStudentsByFacQueryHandler : IRequestHandler<GetStudentsByFacQuery, Result<List<GetStudentsByFacDto>>>
        {
            #region Object References
            private readonly IUnitOfWork _unitOfWork;
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;
            #endregion

            #region Constructor DI
            public GetStudentsByFacQueryHandler(IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _studentRepository = studentRepository;
                _mapper = mapper;
            }
            #endregion

            #region Ovveride Methods
            public async Task<Result<List<GetStudentsByFacDto>>> Handle(GetStudentsByFacQuery request, CancellationToken cancellationToken)
            {
                var entities = await _studentRepository.GetStudentsByFacAsync(request.FacId);
                var student = _mapper.Map<List<GetStudentsByFacDto>>(entities);
                return await Result<List<GetStudentsByFacDto>>.SuccessAsync(student);
            }
            #endregion
        }
    }
}
