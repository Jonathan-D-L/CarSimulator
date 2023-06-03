using UtilityLibrary;

namespace ServiceLibrary.Models
{
    public class Driver
    {
        public string? GivenName { get; set; }
        public string? SurName { get; set; }
        public int Tiredness { get; set; }
        public Hunger Hunger { get; set; }
    }
}
