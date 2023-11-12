using CleanArchEMS.Application.Features.QueriesStudents.GetAllStudents;
using CleanArchEMS.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchEMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        #region Attributs Mediator
        private readonly IMediator _mediator;

        #endregion

        #region Constructor DI
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Verbs
        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllStudentsDto>>>> Get()
        {
            return await _mediator.Send(new GetAllStudentsQuery());
        }
        #endregion
    }
}
