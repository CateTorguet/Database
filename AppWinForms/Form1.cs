using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDFamosos;

namespace AppWinForms
{
    public partial class Form1 : Form
    {
        ColCFamosos colFamosos;
        CFamosoBLL bd;
        public Form1()
        {
            InitializeComponent();

            bd = new CFamosoBLL();
            colFamosos = bd.ObtenerFilasFamosos();
            this.FormClosing += Form1_FormClosing1;
            //Agregar al panel un control elemento lista por cada objeto CfamosoBO
            foreach (CFamosoBO obj in colFamosos)
            {
                ElementoLista elemento = new ElementoLista();
                elemento.ObjetoVinculado = obj;
                this.flowLayoutPanel1.Controls.Add(elemento);
            }
        }

        private void Form1_FormClosing1(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < colFamosos.Count; i++)
            {
                if (colFamosos[i].Modificado)
                {
                    bd.ActualizarFamosos(colFamosos[i]);
                }
            }
        }

    }
}
