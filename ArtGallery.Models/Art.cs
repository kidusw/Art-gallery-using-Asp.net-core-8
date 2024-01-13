using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
	public class Art
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("Art Title")]
		public string Title { get; set; }
		[Required]
		public string Artist { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		[ValidateNever]
		public Category category { get; set; }
		[ValidateNever]
		public string Imageurl { get; set; }

	}
}
