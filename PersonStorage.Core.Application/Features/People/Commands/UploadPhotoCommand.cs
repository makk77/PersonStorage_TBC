using MediatR;
using Microsoft.AspNetCore.Http;
using PersonStorage.Core.Application.Interfaces;
using PersonStorage.Core.Application.Interfaces.Services;

namespace PersonStorage.Core.Application.Features.People.Commands;

public class UploadPhotoRequest : IRequest
{
    public int PersonId { get; set; }
    public IFormFile File { get; set; }
}

public class UploadPhotoHandler : IRequestHandler<UploadPhotoRequest>
{
    private readonly IFileService fileService;
    private readonly IUnitOfWork unit;

    public UploadPhotoHandler(IFileService fileService, IUnitOfWork unit) => (this.fileService, this.unit) = (fileService, unit);

    public async Task Handle(UploadPhotoRequest request, CancellationToken cancellationToken)
    {
        var fileIdentifier = Guid.NewGuid();
        var fileName = $"{fileIdentifier}{fileService.GetExtension(request.File.FileName)}";

        var person = await unit.PersonRepository.GetById(request.PersonId);
        person.PhotoPath = fileName;
        await unit.PersonRepository.Update(person);
        await unit.SaveAsync();

        fileService.UploadPhoto(request.File, fileName);
    }
}
