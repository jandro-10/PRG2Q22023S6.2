using MiPrimerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace MiPrimerApp.ViewModels
{
    public class viewModelCirculo : INotifyPropertyChanged
    {

        public viewModelCirculo() {


            //Apertura de Archivo Lista de Ciculos

            try
            {
                /*Abir y leer el archivo */
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                lista = (ObservableCollection<Circulo>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Personas");

            }

            crear = new Command(() => {

                Circulo c = new Circulo(radio);
                Resultado = c.ToString();
                lista.Add(c);

                //Salvar la Lista en mi telefono
                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, lista);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();
                
                File.WriteAllBytes(ruta, datoSerializados);

            });


        }

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "circulos.bin");

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

        public ObservableCollection<Circulo> lista { get; set; } = new ObservableCollection<Circulo>();

        public Command crear { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
