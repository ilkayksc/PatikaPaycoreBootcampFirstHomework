using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace PaycoreBootcampProject.Controllers
{
    public class Interest
    {
        public double principal { get; set; }
        public double interestRate { get; set; }
        public int expiry { get; set; }
      
        public Interest() { }
    }
    public class InterestGain 
    {
        
        public double InterestAmount { get; set; }
        public double TotalBalance { get; set; }
        public InterestGain() { }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromQuery] Interest request)
        {
            if (request.expiry<0 || request.interestRate<0 ||request.principal<0)
            {
                return BadRequest(request);
            };

            InterestGain interest = new InterestGain();
            
            interest.TotalBalance = request.principal * Math.Pow((1+(request.interestRate / 100)),request.expiry);
            interest.InterestAmount = interest.TotalBalance - request.principal;
            return Ok(interest);
        }
    }
}
