using FinTracker.Domain.Dtos.Import;
using FinTracker.Domain.Dtos.Universal;
using FinTracker.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/import")]
public class ImportController(IImportService importService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<ImportResultDto>>> UploadCsv(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest(ApiResponse<ImportResultDto>.Fail("Файл не передан или пустой"));

        using var stream = file.OpenReadStream();
        using var reader = new StreamReader(stream);

        var result = await importService.ImportAsync(reader, file.FileName);

        return Ok(ApiResponse<ImportResultDto>.Ok(result));
    }
}
