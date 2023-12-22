using System;
using System.ComponentModel;
namespace BDFamosos
{
    public class CFamosoBO : INotifyPropertyChanged
    {
        // Propiedades relacionadas con la tabla famoso
        private int ID;
        private string nombre, apellidos, imagen;
        DateTime cumpleaños;
        private bool modificado;
        public int Id
        {
            get { return ID; }
            set
            {
                ID = value;
                modificado = true;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }
        public string Nombre 
        {
            get { return nombre; }
            set 
            {
                nombre = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nombre"));
            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Apellidos"));
            }
        }
        public string Imagen
        {
            get { return imagen; }
            set
            {
                imagen = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Imagen"));
            }
        }

        public DateTime Cumple
        {
            get { return cumpleaños; }
            set
            {
                cumpleaños = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cumple"));
            }
        }
        public bool Modificado
        {
            get { return modificado; }
            set { modificado = value; }
        }
        public string Edad
        {
            get
            {
                DateTime hoy = DateTime.Now;         //Datetime.Today
                int edad = hoy.Year - cumpleaños.Year;
                if (hoy.DayOfYear < cumpleaños.DayOfYear) 
                {
                    --edad; 
                }
                return String.Format("{0}", edad);
            }
        }
        public string NombreAprellidosEdad
        {
            get
            {
                return nombre + ',' + ' ' + Apellidos + '(' + Edad + ')';
            }
        }



        // Constructores 
        public CFamosoBO() { }
        public CFamosoBO(int id, string nom, string ape, DateTime cum, string ima = null)
        {
            Id = id; Nombre = nom; Apellidos = ape; Cumple = cum; Imagen = ima;
        }

        // Implementación de la interfaz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e); // generar evento
            }
        }
    }
}
