using FinTracker.Domain.Interfaces.Services;
using FinTracker.Domain.ModelsToPrint;
using Microsoft.AspNetCore.Mvc;

namespace FinTracker.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CategoryToPrint[]>> GetAll()
    {   
        var categories = await categoryService.GetAllAsync();
        var result = new CategoryToPrint[categories.Length];
        for (int i = 0; i < categories.Length; i++)
            result[i] = new CategoryToPrint(categories[i]);

        return result;
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<ActionResult<CategoryToPrint>> GetById(Guid id)
    {
        var category = await categoryService.GetByIdAsync(id);
        if (category == null)
            return NotFound();

        return Ok(new CategoryToPrint(category));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryToPrint>> Create(string name)
    {
        if (!await categoryService.IsUniqueNameAsync(name))
            return BadRequest("Ошибка: Такая категория уже существует");

        var createdCategory = await categoryService.CreateAsync(name);
        return Ok(new CategoryToPrint(createdCategory));
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<ActionResult<CategoryToPrint>> Update(Guid id, string name)
    {
        var category = await categoryService.GetByIdAsync(id);

        if (category == null)
            return NotFound($"Категория с id {id} не найдена");

        category.Name = name;

        var success = await categoryService.UpdateAsync(category);

        if (success)
            return Ok(new CategoryToPrint(category));
        else
            return BadRequest($"Категория с названием {name} уже существует");
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await categoryService.DeleteByIdAsync(id);
        if (!success)
            return NotFound($"Категории с id {id} не найдено");
        return Ok();
    }
}
