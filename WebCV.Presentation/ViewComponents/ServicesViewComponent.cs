using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCV.Application.Modules.ServicesModule.Queries.ServiceGetAllQuery;

namespace WebCV.Presentation.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ServicesViewComponent(IMediator mediator){
            this.mediator = mediator; 
        }
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var request = new ServiceGetAllRequest();
            var response = await mediator.Send(request);
            return View(response);
        }

    }
}
