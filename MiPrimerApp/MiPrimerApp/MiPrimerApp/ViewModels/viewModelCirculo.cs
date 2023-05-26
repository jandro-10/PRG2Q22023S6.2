using MiPrimerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MiPrimerApp.ViewModels
{
    public class viewModelCirculo : INotifyPropertyChanged
    {

        public viewModelCirculo() {

            crear = new Command(() => {

                Circulo c = new Circulo(radio);
                Resultado = c.ToString();
            
            });


        }


        double radio;

        public double Radio {

            get => radio;
            set {
                radio = value;
                var args = new PropertyChangedEventArgs(nameof(Radio));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string resultado;

        public string Resultado {
            
            get => resultado;
            set {
            
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        
        }


        public Command crear { get; }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
