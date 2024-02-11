namespace DrugStore4.DrugStoreDb
{
    public class Ad
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public string Dose { get; set; }
        public string Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DrugType DrugType { get; set; }
        public DrugCategory DrugCategory { get; set; }
    }
}
