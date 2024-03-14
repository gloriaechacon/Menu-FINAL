using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Forms
{
    public partial class frmInforme : Form
    {
        AlquilerSalaManager alquilerSalaManager;
        AlquilerInstrumentoManager alquilerInstrumentoManager;
        UsuarioManager usuarioManager;
        ClienteManager clienteManager;
        public frmInforme()
        {
            InitializeComponent();
            alquilerSalaManager = new AlquilerSalaManager();
            clienteManager = new ClienteManager();
            usuarioManager = new UsuarioManager();
            alquilerInstrumentoManager = new AlquilerInstrumentoManager();
        }

        private void frmInforme_Load(object sender, EventArgs e)
        {
            CargarChart();
            CargarGraficos();
            CargarLabels();
        }

        private void CargarChart()
        {
            var query = alquilerSalaManager.AlquileresPorSalas();
            foreach (var item in query)
            {
                chartAlquileresSala.Series["Salas"].Points.AddXY(item[1], Convert.ToInt32(item[2]));
            }

            var query2 = alquilerInstrumentoManager.AlquileresPorInstrumentos();
            foreach (var item in query2)
            {
                chartAlquileresInstrumentos.Series["Instrumentos"].Points.AddXY(item[1], Convert.ToInt32(item[2]));
            }
        }

        private void CargarGraficos()
        {
            var query = alquilerSalaManager.AlquileresPorHoras();
            foreach (var item in query)
            {
                Series serie = chartHorarios.Series.Add(item[0]);
                serie.Label = item[1];
                serie.Points.Add(Convert.ToInt32(item[1]));
            }
        }

        private void CargarLabels()
        {
            var totalAlquileresSala = alquilerSalaManager.TotalAlquileresSala();
            lblSalas.Text = $"${totalAlquileresSala}.00";

            var totalAlquileresInstrumentos = alquilerInstrumentoManager.TotalAlquileresInstrumentos();
            lblInstrumentos.Text = $"${totalAlquileresInstrumentos}.00";

            var clientes =clienteManager.TotalClientes();
            lblClientes.Text = $"{clientes}";

            var usuarios = usuarioManager.TotalEmpleados();
            lblEmpleado.Text = $"{usuarios}";

            lblTotal.Text =  $"${totalAlquileresSala+totalAlquileresInstrumentos}.00";
        }
    }
}
