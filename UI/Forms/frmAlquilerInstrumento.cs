using BE;
using BE.Enums;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Forms
{
    public partial class frmAlquilerInstrumento : Form
    {
        ClienteManager clienteManager;
        AlquilerInstrumentoManager alquilerInstrumentoManager;
        AlquilerInstrumento alquilerInstrumento;
        InstrumentoManager instrManager;
        int alquilerModificadoId;
        bool guardar;
        public frmAlquilerInstrumento()
        {
            InitializeComponent();
            clienteManager = new ClienteManager();
            alquilerInstrumentoManager = new AlquilerInstrumentoManager();
            alquilerInstrumento = new AlquilerInstrumento();
            instrManager = new InstrumentoManager();
            btnCanc.Visible = false;
            CargarCombo();
            CargarComboClliente();
            CargarComboInstrumento();
            CargarPreview();
            CargarData();
        }

        void CargarPreview()
        {
            this.dataGPreview.DataSource = null;
            this.dataGPreview.Rows.Clear();
        }
        private void btnAddReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dateTimePicker1.Value == null || cboCliente.SelectedItem == null || cboPago.SelectedItem == null || dataGPreview.Rows.Count == 0)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else
                {
                    alquilerInstrumento.Total = Convert.ToDouble(lblTotal.Text);
                    alquilerInstrumento.ClienteAsociado = (Cliente)cboCliente.SelectedItem;
                    alquilerInstrumento.Descripcion = txtDesc.Text;
                    alquilerInstrumento.MetodoDePago = (MetodoDePago)cboPago.SelectedValue;
                    alquilerInstrumento.Fecha = dateTimePicker1.Value;
                    var lista = new List<Instrumento>() { };
                    for (int i = 0; i < dataGPreview.Rows.Count; ++i)
                    {
                        lista.Add(new Instrumento() { Id = Convert.ToInt32(dataGPreview.Rows[i].Cells[0].Value)});
                    }
                    alquilerInstrumento.InstrumentosAlquilados = lista;

                    //Si la sala va a ser modificada, guardo el Id en mi objeto
                    if (alquilerModificadoId != 0)
                    {
                        alquilerInstrumento.Id = alquilerModificadoId;
                        btnModifyReserva.Visible = true;
                        btnDeleteReserva.Visible = true;
                        btnCanc.Visible = false;
                    }
                    //Llamo al metodo Guardar de la sala y le paso el objeto
                    guardar = alquilerInstrumentoManager.Guardar(alquilerInstrumento);
                    //Actualizo la grilla
                    CargarData();
                }
            }
            catch (Exception ex)
            {
                //En caso de que ocurra una excepción muestro el cartel de error.
                MessageBox.Show("Ha ocurrido un error. Detalle: " + ex.Message);
            }
            finally
            {
                //Llegado a este punto seteo el resultado de la operación como OK si los datos son validos y cierro el formulario.
                //De lo contrario, indico que hubo un error y dejo el formulario abierto para que el usuario lo cierre
                if (guardar == true)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("¡Operación exitosa!");
                    CargarPreview();
                    CargarCombo();
                    CargarComboClliente();
                    Total();
                    alquilerInstrumento = new AlquilerInstrumento();
                    cboCliente.Enabled = true;
                    btnClienteNuevo.Enabled = true;
                    alquilerModificadoId = 0;
                    guardar = false;
                }
            }
        }

        void CargarCombo()
        {
            cboPago.DataSource = null;
            cboPago.DataSource = Enum.GetValues(typeof(MetodoDePago));
            cboPago.SelectedItem = null;
        }
        void CargarComboClliente()
        {
            cboCliente.DataSource = null;
            cboCliente.DataSource = clienteManager.Listar();
            cboCliente.ValueMember = "Id";
            cboCliente.DisplayMember = "DatosCompletos";
            cboCliente.Refresh();
            cboCliente.SelectedItem = null;
        }

        void CargarComboInstrumento()
        {
            cboInstrumentos.DataSource = null;
            cboInstrumentos.DataSource = instrManager.Listar();
            cboInstrumentos.ValueMember = "Id";
            cboInstrumentos.DisplayMember = "Datos";
            cboInstrumentos.Refresh();
            cboInstrumentos.SelectedItem = null;
        }

        private void frmAlquilerInstrumento_Load(object sender, EventArgs e)
        {

        }

        private void btnClienteNuevo_Click(object sender, EventArgs e)
        {
            frmAltaCliente frm = new frmAltaCliente();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarComboClliente();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VerificarDuplicado();
                if (this.dateTimePicker1.Value == null || cboInstrumentos.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else
                {
                    var instrumentoSeleccionado = (Instrumento)cboInstrumentos.SelectedItem;
                    dataGPreview.Rows.Add(
                        instrumentoSeleccionado.Id,
                        instrumentoSeleccionado.Nombre,
                        instrumentoSeleccionado.Precio
                        );
                    Total();
                    CargarComboInstrumento();
                }
            }
            catch (Exception ex)
            {
                //En caso de que ocurra una excepción muestro el cartel de error.
                MessageBox.Show("Ha ocurrido un error. Detalle: " + ex.Message);
            }
            finally
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGPreview.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dataGPreview.Rows.RemoveAt(dataGPreview.SelectedRows[0].Index);
                }
            }
            Total();
        }
        void Total()
        {
            double sum = 0;
            for (int i = 0; i < dataGPreview.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGPreview.Rows[i].Cells[2].Value);
            }
            lblTotal.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarPreview();
        }

        private void btnModifyReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGAlquileres.Rows.Count == 0) throw new Exception("No hay alquileres para modificar");

                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                title.Text = "Modificacion de alquiler de salas";
                alquilerInstrumento.Descripcion = this.dataGAlquileres.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(this.dataGAlquileres.SelectedRows[0].Cells["Fecha"].Value.ToString());
                cboCliente.SelectedIndex = cboCliente.FindString(this.dataGAlquileres.SelectedRows[0].Cells["Cliente"].Value.ToString());
                cboCliente.Enabled = false;
                btnClienteNuevo.Enabled = false;
                btnModifyReserva.Visible = false;
                btnDeleteReserva.Visible = false;
                btnCanc.Visible = true;
                alquilerModificadoId = (int)this.dataGAlquileres.SelectedRows[0].Cells["IdAlquiler"].Value;
                var instrumentos = alquilerInstrumentoManager.ObtenerInstrumentos(alquilerModificadoId);
                foreach ( var instrumento in instrumentos )
                {
                    dataGPreview.Rows.Add(
                    instrumento.Id,
                    instrumento.Nombre,
                    instrumento.Precio
                    );

                }
                Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                title.Text = "Registro de alquiler de instrumentos";
                cboCliente.Enabled = true;
                btnClienteNuevo.Enabled = true;
                btnModifyReserva.Visible = true;
                btnDeleteReserva.Visible = true;
                btnCanc.Visible = false;
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            cboCliente.Enabled = true;
            CargarComboClliente();
            CargarCombo();
            CargarComboInstrumento();
            CargarPreview();
            btnClienteNuevo.Enabled = true;
            btnModifyReserva.Visible = true;
            btnDeleteReserva.Visible = true;
            btnCanc.Visible = false;
            alquilerModificadoId = 0;
            title.Text = "Registro de alquiler de instrumentos";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerrar formulario
            this.Close();
        }

        private void btnDeleteReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGAlquileres.Rows.Count == 0) throw new Exception("No hay alquileres para borrar");


                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el alquiler?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    int id = (int)this.dataGAlquileres.SelectedRows[0].Cells["IdAlquiler"].Value;

                    alquilerInstrumentoManager.Borrar(id.ToString());
                }
                CargarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CargarData()
        {
            this.dataGAlquileres.DataSource = null;
            this.dataGAlquileres.Rows.Clear();
            var query = alquilerInstrumentoManager.Listar();
            if (query != null)
            {
                query.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
                foreach (var alquiler in query)
                {
                    var instrumentos = alquiler.InstrumentosAlquilados.Select(y => y.Nombre).ToList();
                    string str = String.Join(",", instrumentos);
                    dataGAlquileres.Rows.Add(
                        alquiler.Id,
                        alquiler.Fecha.ToString("dd/MM/yyyy"),
                        alquiler.ClienteAsociado.Datos,
                        alquiler.ClienteAsociado.DNI,
                        str,
                        alquiler.Descripcion,
                        alquiler.MetodoDePago,
                        alquiler.Total);
                }
            }
        }

        private void cboInstrumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void VerificarDuplicado()
        {
            if (cboInstrumentos.SelectedItem != null)
            {
                var seleccionado = ((Instrumento)cboInstrumentos.SelectedItem).Id;
                var lista = new List<int>();
                for (int i = 0; i < dataGPreview.Rows.Count; ++i)
                {
                    lista.Add(Convert.ToInt32(dataGPreview.Rows[i].Cells[0].Value));
                }
                if (lista.Any(x => x == seleccionado))
                {
                    CargarComboInstrumento();
                    throw new Exception("No puede seleccionar dos veces el mismo instrumento");
                }
            }
        }
    }
}
