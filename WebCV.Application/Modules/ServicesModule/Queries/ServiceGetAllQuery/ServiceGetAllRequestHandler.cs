using WebCV.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Application.Modules.ServicesModule.Queries.ServiceGetAllQuery
{
    class ServiceGetAllRequestHandler : IRequestHandler<ServiceGetAllRequest, IEnumerable<ServiceGetAllRequestDto>>
    {
        private readonly IServiceRepository ServiceRepository;

        public ServiceGetAllRequestHandler(IServiceRepository ServiceRepository)
        {
            this.ServiceRepository = ServiceRepository;
        }

        public async Task<IEnumerable<ServiceGetAllRequestDto>> Handle(ServiceGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = ServiceRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var queryResponse = await query.Select(m => new ServiceGetAllRequestDto
            {
                Id = m.Id,
                CssClass = m.CssClass,
                Title = m.Title,
                Description = m.Description,
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }

    }
}
