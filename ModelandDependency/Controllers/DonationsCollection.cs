namespace ModelandDependency.Controllers
{
    public class DonationsCollection
    {
        private int sumOfDonations = 0;
        /// <summary>
        /// The sum of donations so far.
        /// </summary>
        public int SumofDonations => sumOfDonations;

        public void AddDonation(int amount)
        {
            sumOfDonations += amount;
        }
    }
}