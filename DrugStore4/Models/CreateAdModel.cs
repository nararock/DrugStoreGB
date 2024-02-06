namespace DrugStore4.Models
{
    public class CreateAdModel
    {
        public List<SimpleCommonModel> typeAd {  get; set; }
        public List<SimpleCommonModel> categoryAd { get; set; }
        public CreateAdModel(List<SimpleCommonModel> type, List<SimpleCommonModel> category) {
            this.typeAd = type;
            this.categoryAd = category;
        }
    }
}
