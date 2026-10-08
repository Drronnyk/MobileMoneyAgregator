using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileMoneyAgregator.Helpers;

[Authorize]
[ApiController]
[Route("api/payments")]

public class PaymentsController: ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PaymentService _paymentService;

    public PaymentsController(AppDbContext context, PaymentService paymentService)
    {
        _context = context;
        _paymentService = paymentService;
    }
    [HttpPost("initiate")]
    public async Task<IActionResult> Initiate([FromBody] InitiatePaymentDto dto)

    {
        var merchantId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var transaction = new Transaction
        {
            MerchantId = merchantId,
            Montant = dto.Amount,
            ProviderName = dto.Provider,
            PaymentStatus = StatusTransaction.Pending,
            PhoneCustomer = dto.PhoneNumber,
            DateCreation = DateTime.UtcNow


        };
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        
        var result = await _paymentService.InitiatePayment(dto.Provider,dto.Amount,dto.PhoneNumber);
        transaction.PaymentStatus = result.TransactionStatus;
        await _context.SaveChangesAsync();

        return Ok(
            new
            {
                transaction.Id,
                result.ReferencePayment,
                transaction.PaymentStatus

            }
        );
        
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {
        var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id ==id );
        if(transaction == null)
        {
            return NotFound("Cette Transaction n'existe pas.");
        }
         var merchantId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
         if(merchantId != transaction.MerchantId)
        {
            return StatusCode(403,"Vous n'etes pas autorisé à consulter cette transaction");
        }
        return Ok(transaction);
        
    
    
    
    }
}