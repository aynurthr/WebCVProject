//using WebCV.Application.Repositories;
//using MediatR;
//using Microsoft.AspNetCore.Mvc.Infrastructure;
//using Microsoft.EntityFrameworkCore;

//namespace WebCV.Application.Modules.PersonModule.Queries.PersonGetAllQuery
//{
//    class PersonGetAllRequestHandler : IRequestHandler<PersonGetAllRequest, IEnumerable<PersonGetAllRequestDto>>
//    {
//        private readonly IPersonRepository personRepository;
//        private readonly IActionContextAccessor ctx;

//        public PersonGetAllRequestHandler(IPersonRepository personRepository, IActionContextAccessor ctx)
//        {
//            this.personRepository = personRepository;
//            this.ctx = ctx;
//        }

//        public async Task<IEnumerable<PersonGetAllRequestDto>> Handle(PersonGetAllRequest request, CancellationToken cancellationToken)
//        {
//            var query = personRepository.GetAll();

//            if (request.OnlyAvailable)
//            {
//                query = query.Where(m => m.DeletedAt == null);
//            }

//            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";
//            var queryResponse = await query.Select(m => new PersonGetAllRequestDto
//            {
//                Id = m.Id,
//                Title = m.Title,
//                Body = m.Body,
//                ImageUrl = $"{host}/uploads/files/{m.ImagePath}",
//            }).ToListAsync(cancellationToken);

//            return queryResponse;
//        }

//    }
//}
