using MediatR;
using SharedKernel.Result;

namespace WebApi.Api
{
    public class HomeController : BaseApi
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result> Get()
        {
            return Result.Success();
        }
    }
}
