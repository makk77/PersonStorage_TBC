﻿using Microsoft.AspNetCore.Http;

namespace PersonStorage.Core.Application.Interfaces.Services;

public interface IFileService
{
    void UploadPhoto(IFormFile file, string fileName);

    string GetExtension(string filename);
}
