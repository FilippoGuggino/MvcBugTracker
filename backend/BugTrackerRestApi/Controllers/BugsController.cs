using BugTrackerRestApi.Models;
using BugTrackerRestApi.Services;
using Microsoft.AspNetCore.Mvc;

using System;

namespace BugTrackerRestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BugsController : ControllerBase
{
    private readonly BugsService _bugsService;

    public BugsController(BugsService bugsService) =>
        _bugsService = bugsService;

    [HttpGet]
    public async Task<List<Bug>> Get() =>
        await _bugsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Bug>> Get(string id)
    {
        Console.WriteLine(id);

        var bug = await _bugsService.GetAsync(id);

        if (bug is null)
        {
            return NotFound();
        }

        return bug;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Bug newBug)
    {
        await _bugsService.CreateAsync(newBug);

        return CreatedAtAction(nameof(Get), new { id = newBug.Id }, newBug);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Bug updatedBug)
    {
        var bug = await _bugsService.GetAsync(id);

        if (bug is null)
        {
            return NotFound();
        }

        updatedBug.Id = bug.Id;

        await _bugsService.UpdateAsync(id, updatedBug);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var bug = await _bugsService.GetAsync(id);

        if (bug is null)
        {
            return NotFound();
        }

        await _bugsService.RemoveAsync(id);

        return NoContent();
    }
}