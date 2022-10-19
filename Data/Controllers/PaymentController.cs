using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using OnlineStore.Models;
using OnlineStore.Data.Services;
using Microsoft.AspNetCore.Authorization;

namespace OnlineStore.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestService _orderService;
        private readonly string secret_key = "sdfew1fe51wf6-e1w5f61wef6-ew15f6we1f55we-1ew5f61ewf";

        public PaymentController(
            ApplicationDbContext context,
            IRequestService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<string>> New([FromQuery] string secret, [FromQuery] decimal monto, [FromQuery] int order_Id)
        {
            if (ModelState.IsValid)
            {
                if (secret != secret_key)
                    return "*bad*";
                var order = await _orderService.GetById(order_Id);
                var order_amount = order.Price + order.Shipping_price;
                if (order_amount != monto)
                    return "*bad*";
                await _orderService.MarkAsPaid(order_Id);
                return "*ok*";
            }
            return "*bad*";
        }
    }
}
