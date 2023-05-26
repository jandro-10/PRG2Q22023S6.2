using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimerApp.Models
{
    public class Circulo
    {

        public double radio { get; set; }
        public double perimetro { get; set; }
        public double area { get; set; }

        public Circulo(double r) {
            
            radio = r;
            calcularArea();
            calcularPerimetro();
        } 

        public void calcularArea()
        {
            area = (Math.Pow(radio, 2)) * Math.PI;
        }

        public void calcularPerimetro() { 
        
            perimetro = 2 * Math.PI * radio;
        }

        public override string ToString()
        {
            return $" Area: {area} -  Perimetro: {perimetro} ";
        }

    }
}
