using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        [JsonIgnore]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = [];
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}