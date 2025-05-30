using Lab10.Application.DTOs.Roles;
using Lab10.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
    {
        try
        {
            var created = await _roleService.CreateRoleAsync(dto);
            return CreatedAtAction(nameof(GetRoles), new { id = created.RoleId }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }
}