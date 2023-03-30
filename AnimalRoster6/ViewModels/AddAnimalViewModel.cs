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

        public AnimalHandler Handler { get; set; }

        public List<SelectListItem> AnimalHandlers { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(AnimalHandler.Gerard.ToString(), ((int)AnimalHandler.Gerard).ToString()), // ("Gerard", "0")
            new SelectListItem(AnimalHandler.Patrick.ToString(), ((int)AnimalHandler.Patrick).ToString()), // ("Patrick", "1")
            new SelectListItem(AnimalHandler.Nasya.ToString(), ((int)AnimalHandler.Nasya).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Cory.ToString(), ((int)AnimalHandler.Cory).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Maggie.ToString(), ((int)AnimalHandler.Maggie).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Justus.ToString(), ((int)AnimalHandler.Justus).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Rick.ToString(), ((int)AnimalHandler.Rick).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Ashley.ToString(), ((int)AnimalHandler.Ashley).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Mario.ToString(), ((int)AnimalHandler.Mario).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Sarah.ToString(), ((int)AnimalHandler.Sarah).ToString()), // ("Gerard", "1")
            new SelectListItem(AnimalHandler.Jose.ToString(), ((int)AnimalHandler.Jose).ToString()), // ("Gerard", "1")


        };
    }
}

