using Microsoft.AspNetCore.Mvc;
using ProjectECommerce_Api.DalClasses;
using ProjectECommerce_Api.Models;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaymentsController : ControllerBase
    {
        BasketDal basketDal=new BasketDal();
        PaymentDal paymentDal=new PaymentDal();
         
        [HttpPost]
        public async Task<ActionResult> AddPaymentDeleteBasket(int id,PaymentOption paymentOption,int basketid)
        {
            var result = paymentDal.PaymentAddAndBasketDelete(id, paymentOption, basketid);
            if (result==true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
