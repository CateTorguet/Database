using BDFamosos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWinForms
{
    public partial class ElementoLista : UserControl
    {
        public ElementoLista()
        {
            InitializeComponent();
            Binding bImagen = this.pictureBox1.DataBindings["Image"];
            bImagen.Format += this.StringToBitmap;
        }

        public CFamosoBO ObjetoVinculado
        {
            get { return this.famosoBindingSource.DataSource as CFamosoBO; }
            set
            {
                this.famosoBindingSource.DataSource = value;
                
                if (value != null)
                {
                    string msj = "Famoso número " + value.Id;
                    this.ttElementoList.SetToolTip(this.pictureBox1, msj);
                }
            }
        }
        private string ObtenerRutaImagen(string nombreImagen)
        {
            string carpeta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            carpeta = Path.Combine(carpeta, "Imagenes");
            return Path.Combine(carpeta, nombreImagen);
        }

        private void StringToBitmap(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(Image)) return;
            e.Value = Bitmap.FromFile(ObtenerRutaImagen(e.Value as string));
        }
    }
}
