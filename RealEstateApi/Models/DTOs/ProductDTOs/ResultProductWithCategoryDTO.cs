namespace RealEstateApi.Models.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int Product_ID { get; set; }
        public string Product_Title { get; set; }
        public decimal Product_Price { get; set; }
        public string Product_city { get; set; }
        public string Product_district { get; set; }
        public string Category_Name { get; set; }
    }
}
