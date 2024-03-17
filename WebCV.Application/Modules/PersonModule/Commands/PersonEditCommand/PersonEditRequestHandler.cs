using MediatR;
using WebCV.Application.Repositories;
using WebCV.Infrastructure.Abstracts;

namespace WebCV.Application.Modules.PersonModule.Commands.PersonEditCommand
{
    class PersonEditRequestHandler : IRequestHandler<PersonEditRequest>
    {
        private readonly IPersonRepository personRepository;
        private readonly IFileService fileService;

        public PersonEditRequestHandler(IPersonRepository personRepository, IFileService fileService)
        {
            this.personRepository = personRepository;
            this.fileService = fileService;
        }

        public async Task Handle(PersonEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await personRepository.GetAsync(m => m.Id == request.Id);

            entity.FullName = request.FullName;
            entity.Experience = request.Experience;
            entity.DateOfBirth = request.DateOfBirth;
            entity.Location = request.Location;
            entity.Degree = request.Degree;
            entity.Bio = request.Bio;
            entity.Fax = request.Fax;
            entity.CareerLevel = request.CareerLevel;
            entity.Website = request.Website;

            entity.Phone = request.Phone;
            entity.Email = request.Email;


            if (request.Attachment is not null)
            {
                entity.AttachmentPath = await fileService.ChangeFileAsyncFile(entity.AttachmentPath, request.Attachment);
            }

            await personRepository.SaveAsync(cancellationToken);
        }

    }
}

