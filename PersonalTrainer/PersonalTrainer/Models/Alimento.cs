using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Models
{
    public class Alimento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(30, ErrorMessage = "El nombre debe posee maximo 30 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una caloría.")]
        public float Calorias { get; set; }
        [Display(Name ="Grasas totales")]
        [Required(ErrorMessage ="Debe ingresar las grasas totales.")]
        public float GrasasTotales { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cantidad de proteína")]
        public float Proteina { get; set; }
        [Required(ErrorMessage ="debe ingresar los carbohidratos.")]
        public float Carbohidratos { get; set; }
        public float Sodio { get; set; }
        public float Potacio { get; set; }
        public float Fibra { get; set; }
        public float Azucares { get; set; }
        [Display(Name ="Vitamina A")]
        public float VitaminaA { get; set; }
        [Display(Name = "Vitamina C")]
        public float VitaminaC { get; set; }
        public float Calcio { get; set; }
        public float Hierro { get; set; }
    }
}
//vitamina a,c,e,sodio,magnesio,calcio,potasio