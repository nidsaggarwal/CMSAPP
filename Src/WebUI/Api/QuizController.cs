using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Result;

namespace WebApi.Api
{
    public class QuizController : BaseApi
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }
         
    }
}
