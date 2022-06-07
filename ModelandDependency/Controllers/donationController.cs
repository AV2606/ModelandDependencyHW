using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ModelandDependency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class donationController : ControllerBase
    {
        private readonly DonationsCollection donations;
        private readonly EvilDonationsCollector collector;

        public donationController(DonationsCollection donations, EvilDonationsCollector collector)
        {
            this.donations = donations;
            this.collector = collector;
        }
        
        [HttpPost("give/{firstName}/{lastName}")]
        public async Task<IActionResult> Donate(
            [FromRoute] string firstName,
            [FromRoute] string lastName,
            [FromQuery] int amount,
            [FromQuery] string companyId,
            [FromBody] DonateObject donateObject)
        {
            donations.AddDonation(amount);
            collector.AddDonation(amount, companyId);
            
            var ret = new
            {
                Name = firstName + " " + lastName,
                Amount = amount,
                AmutaNumber = companyId,
                DateOfDonation = donateObject.donationDate,
                Generosity = donateObject.Generosity,
                SumOfDonations = this.donations.SumofDonations,
                Donators=collector.Donators
            };
            return Ok(ret);
        }
    }
}
