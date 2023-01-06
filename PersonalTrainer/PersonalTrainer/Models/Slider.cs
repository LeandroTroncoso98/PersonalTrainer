using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Models
{
    public class Slider
    {
        [Key]
        
        public int Id { get; set;}
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede poseer mas de 30 caracteres.")]
        [Display(Name="Nombre: ")]
        public string Nombre { get; set; }
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen a subír: ")]
        public string ImagenUrl { get; set; }
        [Display(Name ="Visible: ")]
        public bool Estado { get;set; }

    }
}
