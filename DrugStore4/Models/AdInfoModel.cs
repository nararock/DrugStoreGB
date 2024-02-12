using Azure.Identity;

namespace DrugStore4.Models
{
    public class AdInfoModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Dose { get; set; }
        public string Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string? Nickname { get; set; }
        public string? UserPhone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
