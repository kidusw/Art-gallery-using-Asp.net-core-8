using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string? Name { get; set; }
		public DateTime dateJoined { get; set; }
	}
}
