using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Title { get; set; } = "New DotNet Product";
        public String? Vendor { get; set; }
        public String? ProductType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public String? TemplateSuffix { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Draft;
        public String? PublishedScope { get; set; }
        public int? ImageId { get; set; }
    }
}