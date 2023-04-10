using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalRoster6.ViewModels
{
	public class AddCaretakerViewModel
	{
        [Required(ErrorMessage = "Hey buddy I need a name, thanks. 🙂")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Not so fast. Names must be between 3 and 20 characters in length.")]
        public string? Name { get; set; }
	}
}

