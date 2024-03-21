using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCV.Application.Modules.ContactPostsModule.Commands.ContactPostApplyCommand;
using WebCV.Application.Modules.PersonModule.Commands.PersonEditCommand;
using WebCV.Application.Modules.PersonModule.Queries.PersonGetByIdQuery;
using WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery;
using WebCV.Presentation.ViewModels.PersonSkillViewModels;

namespace WebCV.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(PersonGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Edit([FromRoute] PersonGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] PersonEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Resume(PersonSkillGetAllRequest request)
        {
            var response = await mediator.Send(request);

            var skillsByTypeAndGroup = response
                .GroupBy(s => new { s.TypeId, s.TypeName })
                .Select(typeGroup => new SkillTypeGroupViewModel // Replace with actual ViewModel
                {
                    TypeId = typeGroup.Key.TypeId,
                    TypeName = typeGroup.Key.TypeName,
                    Groups = typeGroup
                                .GroupBy(s => new { s.GroupId, s.GroupName })
                                .Select(groupGroup => new SkillGroupViewModel // Replace with actual ViewModel
                                {
                                    GroupId = groupGroup.Key.GroupId,
                                    GroupName = groupGroup.Key.GroupName,
                                    Skills = groupGroup.ToList()
                                })
                                .ToList()
                })
                .ToList();

            return View(skillsByTypeAndGroup);

        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactPostApplyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                ModelState.AddModelError("FullName", "Ad doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                ModelState.AddModelError("Email", "Email doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                ModelState.AddModelError("Subject", "Subject doldurulmayib");
            }

            if (string.IsNullOrWhiteSpace(request.Message))
            {
                ModelState.AddModelError("Message", "Message doldurulmayib");
            }

            if (ModelState.IsValid)
            {
                await mediator.Send(request);
                return Json(new
                {
                    error = false,
                    message = "",
                    errors = new Dictionary<string, IEnumerable<string>>()
                });
            }

            //List< KeyValuePair<string,ModelStateEntry> > 

            var errors = ModelState.Select(m => new
            {
                Property = m.Key,
                Messages = m.Value.Errors.Select(m => m.ErrorMessage)
            })
                .ToDictionary(m => m.Property, v => v.Messages);

            return BadRequest(new
            {
                error = true,
                message = "Xəta var",
                errors = errors
            });
        }

    }
}

