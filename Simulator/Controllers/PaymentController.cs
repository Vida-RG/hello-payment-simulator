using Microsoft.AspNetCore.Mvc;
using Simulator.Models;
using System;

namespace Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [ProducesResponseType(typeof(PaymentState), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost]
        public IActionResult Post([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest.CardNumber.EndsWith('9'))
            {
                return BadRequest("Property error of card details (simulated validation error)");
            }

            if (paymentRequest.CardNumber.EndsWith('8'))
            {
                return Ok(
                    new PaymentState
                    {
                        Code = PaymentStatusCode.Unsuccessful,
                        Id = Guid.NewGuid().ToString()
                    });
            }

            return Ok(
                new PaymentState
                {
                    Code = PaymentStatusCode.Success,
                    Id = Guid.NewGuid().ToString()
                });
        }
    }
}
