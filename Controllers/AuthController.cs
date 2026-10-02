using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileMoneyAgregator.Models.Merchant;
using MobileMoneyAgregator.Services.JwtServices;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, IConfiguration config, JwtService jwtService)
    {
        _context = context;
        _config = config;
        _jwtService = jwtService;
    }
    [HttpPost("register")]
    public  async Task<IActionResult> Register([FromBody] RegisterMerchantDto dto)
    {
        if(await _context.Merchants.AnyAsync(m => m.Email == dto.Email))
        {
            return BadRequest("Cet utilisateur existe deja");
        }
        var passwordHash = new PasswordHasher<Merchant>().HashPassword(null!,dto.Password);
        var apiKey = Guid.NewGuid().ToString();
        var merchant = new Merchant
        {
            NameEnterprise = dto.NameEnterprise,
            Email = dto.Email,
            PasswordHash = passwordHash,
            ApiKey = apiKey,
            DateCreation = DateTime.UtcNow

        };
        _context.Merchants.Add(merchant);
        await _context.SaveChangesAsync();
       var response = new AuthResponseDto
       {
        MerchantId = merchant.Id,
        NameEnterprise = merchant.NameEnterprise,
        Token = _jwtService.GenerateToken(merchant)
       };
       return Ok(response);


        
    }
    [HttpPost("login")]
    public async Task<IActionResult>Login([FromBody]LoginDto dto)
    {
      var merchant = await _context.Merchants.FirstOrDefaultAsync(m => m.Email == dto.Email);
      if(merchant == null)
        {
            return Unauthorized("Email ou Mot de Passe Incorrect");
        }
        var result = new PasswordHasher<Merchant>().VerifyHashedPassword(merchant,merchant.PasswordHash, dto.Password);
        if(result == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Email ou Mot de Passe Incorrect");
        }
        var response = new AuthResponseDto
{
    MerchantId = merchant.Id,
    NameEnterprise = merchant.NameEnterprise,
    Token = _jwtService.GenerateToken(merchant)
};

return Ok(response);
    }
    
} 