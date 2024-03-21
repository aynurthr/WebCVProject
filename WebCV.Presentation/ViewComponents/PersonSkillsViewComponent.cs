using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery;

namespace WebCV.Presentation.ViewComponents
{
    public class PersonSkillsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public PersonSkillsViewComponent(IMediator mediator){
            this.mediator = mediator; 
        }
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var request = new PersonSkillGetAllRequest();
            var response = await mediator.Send(request);
            return View(response);
        }

    }
}
