using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCV.Application.Modules.PersonModule.Queries.PersonGetByIdQuery;

namespace WebCV.Presentation.ViewComponents
{
    public class SkillsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public SkillsViewComponent(IMediator mediator){
            this.mediator = mediator; 
        }
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var request = new PersonGetByIdRequest();
            var response = await mediator.Send(request);
            return View(response);
        }

    }
}
