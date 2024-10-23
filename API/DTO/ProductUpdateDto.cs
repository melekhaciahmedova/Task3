namespace API.DTO
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public Guid ParentCategoryId { get; set; }
        public List<Guid> ChildCategoryIds { get; set; }
    }
}