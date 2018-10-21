namespace Web.Site.Product.Application.Dto
{
    using Web.Site.Common.Domain.Enum;

    public class ProductOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
    }
}
