namespace MiniJackPotManager.Models
{
    public class Jackpot
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal HitThreshold { get; set; }
        public decimal SeedValue { get; set; }
    }
}
