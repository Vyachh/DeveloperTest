namespace BMIWebApi.Models
{
    public class BMIThresholds
    {
        public int Id { get; set; } 
        public double IndexFrom { get; set; }
        public double IndexTo{ get; set; }
        public string Description { get; set; }
    }
}
