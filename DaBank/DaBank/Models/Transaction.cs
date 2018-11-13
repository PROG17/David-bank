namespace DaBank.Models
{
    public class Transaction
    {
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public decimal Amount { get; set; }
    }
}