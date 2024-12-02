using AdventOfCode.Application.Handler.Solution.Model;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AdventOfCode.API.Controllers;

[Route("AdventOfCode/[controller]/")]
public class SolutionController : Controller
{
    private readonly IMediator _mediator;

    public SolutionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("{year}/{day}/{part}")]
    public async Task<IActionResult> GetByDayAndPart([FromRoute] int year, [FromRoute] int day, [FromRoute] int part)
    {
        if(part < 1 || part > 2) 
        {
            return BadRequest(new Exception("Only result for part 1 or two can be asked"));  
        }

        var command = new GetSolutionCommand(year, day, part);

        var commandResult = await _mediator.Send(command);

        if (commandResult.IsError) 
        {
            return BadRequest(commandResult.Error);
        }

        return Ok(commandResult.Value);
    }
}
