using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class PhotoModel
    {
        public IFormFile file { get; set; }
        public int productId { get; set; }
    }
}