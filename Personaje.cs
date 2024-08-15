using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeleaPersonajes
{
    public class Personaje
    {
        public Personaje(string Name, int PS, int Dmg, double Esq)
        {
            this.Name = Name;
            this.PuntosSalud = PS;
            this.DamageMaximo = Dmg;
            this.Esquivar = Esq;
        }

        public string Name { get; set; }
        public int PuntosSalud { get; set; }
        public int DamageMaximo { get; set; }
        public double Esquivar { get; set; }
    }
}
