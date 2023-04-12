using System;
using System.ComponentModel.DataAnnotations;
using AnimalRoster6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [Required(ErrorMessage = "Don't be lazy.")]
        [StringLength(255, ErrorMessage = "255 is the max length for descriptions.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = ":(")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? ImgUrl { get; set; }

        [Required(ErrorMessage = "Hey don't forget that you need a Caretaker :)")]
        public int CaretakerId { get; set; }

        public List<SelectListItem>? Caretakers { get; set; }

        public AddAnimalViewModel(List<AnimalCaretaker> caretakers)
        {
            Caretakers = new List<SelectListItem>();

            foreach (var caretaker in caretakers)
            {
                Caretakers.Add(new SelectListItem
                {
                    Value = caretaker.Id.ToString(),
                    Text = caretaker.Name
                });
            }
        }

        public AddAnimalViewModel() { }
    }
}

