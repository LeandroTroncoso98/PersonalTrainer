using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Data.Repositorio
{
    public interface IContenedorTrabajo : IDisposable
    {
        ISliderRepository Slider { get; }
        void Save();
    }
}
