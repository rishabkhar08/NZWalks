using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum 2 characters are required")]
        [MaxLength(4, ErrorMessage = "Maximum 4 characters allowed")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
