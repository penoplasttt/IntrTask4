using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Task4.Data;

namespace Task4.ViewComponent;
using Microsoft.AspNetCore.Mvc;
public class NameViewComponent: ViewComponent {
    private readonly ApplicationDbContext _context;

    public NameViewComponent(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claimsIdentity = (ClaimsIdentity?)User.Identity;
        var claims = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == claims.Value);

        return View(user);
    }
}