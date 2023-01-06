using PersonalTrainer.Data.Repositorio;
using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Data
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;
        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Slider slider)
        {
            var objDesdeDb = _db.Slider.FirstOrDefault(m => m.Id == slider.Id);
            objDesdeDb.Nombre = slider.Nombre;
            objDesdeDb.ImagenUrl = slider.ImagenUrl;
            objDesdeDb.Estado = slider.Estado;
            _db.SaveChanges();
        }
    }
}
