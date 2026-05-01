//using FinTracker.Domain.Dtos.Universal;
//using MapsterMapper;
//using Microsoft.AspNetCore.Mvc;

//namespace FinTracker.API.Controllers;

//[ApiController]
//[Route("api/transactions/{id:guid}/items")]
//public class ItemsController(IItemService itemService,
//    IMapper mapper) : ControllerBase
//{
//    [HttpGet]
//    public async Task<ActionResult<ApiResponse<IEnumerable<dto>>>> GetAll()
//    {
//        throw new NotImplementedException();
//    }

//    [HttpPost]
//    public async Task<ActionResult<ApiResponse<dto>>> Create([FromBody] dto2)
//    {
//        throw new NotImplementedException();
//    }

//    [HttpPut("{itemId:guid}")]
//    public async Task<ActionResult<ApiResponse<dto>>> Update(Guid itemId, [FromBody] dto3)
//    {
//        throw new NotImplementedException();
//    }

//    [HttpDelete]
//    public async Task<ActionResult<ApiResponse<dto>>> Delete(Guid itemId)
//    {
//        throw new NotImplementedException();
//    }
//}
