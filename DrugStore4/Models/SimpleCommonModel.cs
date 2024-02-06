namespace DrugStore4.Models
{
    public class SimpleCommonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SimpleCommonModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
