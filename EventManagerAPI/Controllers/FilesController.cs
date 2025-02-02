using System;
using System.Reflection.Metadata;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace EventManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController:  ControllerBase
{
    public readonly BlobServiceClient _blobServiceClient;

    public FilesController(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("event-files");
        await containerClient.CreateIfNotExistsAsync();

        var blobClient = containerClient.GetBlobClient(file.FileName);
        await blobClient.UploadAsync(file.OpenReadStream(), overwrite: true);

        return Ok(new { FileName = file.FileName });
    }

}
