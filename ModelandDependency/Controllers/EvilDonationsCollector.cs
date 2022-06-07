using System.Collections.Generic;

namespace ModelandDependency.Controllers
{
    public class EvilDonationsCollector
    {
        public List<Donator> Donators { get; set; }=new List<Donator>();

        public void AddDonation(int amount, string companyId)
        {
            Donators.Add(new Donator() { Amount = amount, CompanyId = companyId });
        }
    }

    public class Donator
    {
        public string CompanyId { get; set; }
        public int Amount { get; set; }
    }
}