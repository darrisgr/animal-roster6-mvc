using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalRoster6.ViewModels
{
	public class AddAnimalViewModel
	{
		[Required(ErrorMessage = "Hey buddy I need a name, thanks. 🙂")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Not so fast. Names must be between 3 and 50 characters in length.")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Just do it.")]
		[StringLength(50, ErrorMessage = "Bad.")]
		public string? Species { get; set; }
		[Required (ErrorMessage = "Don't be lazy.")]
		[StringLength(255, ErrorMessage = "255 is the max length for descriptions.")]
		public string? Description { get; set; }
		[Required(ErrorMessage = ":(")]
		[Url(ErrorMessage = "Invalid URL format.")]
		public string? ImgUrl { get; set; }


	}
}

