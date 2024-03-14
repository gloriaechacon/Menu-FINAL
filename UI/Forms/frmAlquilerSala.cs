using BE;
using BE.Enums;
using BL;
using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmAlquilerSala : Form
    {
        SalaManager salaManager;
        ClienteManager clienteManager;
        AlquilerSalaManager alquilerManager;
        AlquilerSala alquiler;
        int alquilerModificadoId = 0;
        bool guardar;
        public frmAlquilerSala()
        {
            InitializeComponent();
            salaManager = new SalaManager();
            clienteManager = new ClienteManager();
            alquilerManager = new AlquilerSalaManager();
            alquiler = new AlquilerSala();
            btnCanc.Visible = false;
            CargarRadioButton();
            CargarComboClliente();
            CargarComboSala();
            CargarCombo();
            CargarData();
        }

        private void btnClienteNuevo_Click(object sender, EventArgs e)
        {
            frmAltaCliente frm = new frmAltaCliente();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                CargarComboClliente();
            }
        }

        private void frmAlquilerSala_Load(object sender, EventArgs e)
        {

        }

        private void btnAddReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dateTimePicker1.Value == null || cboSala.SelectedItem == null || cboCliente.SelectedItem == null || cboPago.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else
                {
                    alquiler.SalaAlquilada = (Sala)cboSala.SelectedItem;
                    alquiler.Descripcion = txtDesc.Text;
                    alquiler.Total = alquiler.SalaAlquilada.Precio;
                    alquiler.ClienteAsociado =(Cliente)cboCliente.SelectedItem;
                    alquiler.MetodoDePago = (MetodoDePago)cboPago.SelectedValue;
                    alquiler.Fecha = dateTimePicker1.Value;
                    if (radioMorning.Checked)
                    {
                        alquiler.Hora = "9:00";
                    }
                    else if (radioNoon.Checked)
                    {
                        alquiler.Hora = "13:00";
                    }
                    else
                    {
                        alquiler.Hora = "18:00";
                    }

                    //Si la sala va a ser modificada, guardo el Id en mi objeto
                    if (alquilerModificadoId != 0)
                    {
                        alquiler.Id = alquilerModificadoId;
                        btnModifyReserva.Visible = true;
                        btnDeleteReserva.Visible = true;
                        btnCanc.Visible = false;
                    }
                    //Llamo al metodo Guardar de la sala y le paso el objeto
                    guardar = alquilerManager.Guardar(alquiler);
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
                    title.Text = "Registro de alquiler de salas";
                    MessageBox.Show("¡Operación exitosa!");
                    CargarRadioButton();
                    CargarData();
                    Limpiar();
                    alquiler = new AlquilerSala();
                    cboCliente.Enabled = true;
                    btnClienteNuevo.Enabled = true;
                    alquilerModificadoId = 0;
                    guardar = false;
                }
            }
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

        void CargarComboSala()
        {
            cboSala.DataSource = null;
            cboSala.DataSource = salaManager.Listar();
            cboSala.ValueMember = "Id";
            cboSala.DisplayMember = "Datos";
            cboSala.Refresh();
            cboSala.SelectedItem = null;
        }

        void CargarRadioButton()
        {
            radioMorning.Enabled = false;
            radioNoon.Enabled = false;
            radioAfternoon.Enabled = false;
        }

        void CargarData()
        {
            this.dataGAlquileres.DataSource = null;
            this.dataGAlquileres.Rows.Clear();
            var query = alquilerManager.Listar();
            if (query != null)
            {
                query.Sort((x, y) => DateTime.Compare(x.Fecha, y.Fecha));
                foreach (var alquiler in query)
                {
                    dataGAlquileres.Rows.Add(
                        alquiler.Id,
                        alquiler.Fecha.ToString("dd/MM/yyyy"), 
                        alquiler.Hora, 
                        alquiler.ClienteAsociado.Datos, 
                        alquiler.ClienteAsociado.DNI, 
                        alquiler.SalaAlquilada.Codigo, 
                        alquiler.SalaAlquilada.Nombre,
                        alquiler.Descripcion,
                        alquiler.MetodoDePago,
                        alquiler.Total);
                }
            }
        }

        void Limpiar()
        {
            CargarComboSala();
            CargarComboClliente();
            txtDesc.Text = string.Empty;
            label10.Text = "TOTAL : $ 0000.000";
            CargarCombo();
        }
        void CargarCombo()
        {
            cboPago.DataSource = null;
            cboPago.DataSource = Enum.GetValues(typeof(MetodoDePago));
            cboPago.SelectedItem = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboSala.SelectedItem != null)
            {
                CargarRadioButton();
                var fecha = this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
                var sala = (Sala)cboSala.SelectedItem;
                var horas = alquilerManager.BuscarDisponibilidad(fecha, sala.Id);
                if (horas.Count == 0)
                {
                    MessageBox.Show("No hay horarios disponibles para esta fecha, seleccione otra fecha o sala");
                }
                else
                {
                    if (horas.Contains("9:00"))
                    {
                        radioMorning.Enabled = true;
                    }
                    if (horas.Contains("13:00"))
                    {
                        radioNoon.Enabled = true;
                    }
                    if (horas.Contains("18:00"))
                    {
                        radioAfternoon.Enabled = true;
                    }

                    label10.Text = $"TOTAL : $ {sala.Precio}";
                }
            }
            else
            {
                MessageBox.Show("Seleccione una sala y una fecha para buscar disponibiidad");
            }
        }

        private void btnModifyReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGAlquileres.Rows.Count == 0) throw new Exception("No hay alquileres para modificar");

                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                CargarRadioButton();
                title.Text = "Modificacion de alquiler de salas";
                alquiler.Descripcion = this.dataGAlquileres.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(this.dataGAlquileres.SelectedRows[0].Cells["Fecha"].Value.ToString());
                cboCliente.SelectedIndex = cboCliente.FindString(this.dataGAlquileres.SelectedRows[0].Cells["Cliente"].Value.ToString());
                cboCliente.Enabled = false;
                cboSala.SelectedIndex = cboCliente.FindString(this.dataGAlquileres.SelectedRows[0].Cells["NombreSala"].Value.ToString());
                btnClienteNuevo.Enabled = false;
                btnModifyReserva.Visible = false;
                btnDeleteReserva.Visible = false;
                btnCanc.Visible = true;
                alquilerModificadoId = (int)this.dataGAlquileres.SelectedRows[0].Cells["IdAlquiler"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Limpiar();
                CargarRadioButton();
                cboCliente.Enabled = true;
                btnClienteNuevo.Enabled = true;
                btnModifyReserva.Visible =true;
                btnDeleteReserva.Visible = true;
                btnCanc.Visible = false;
            }
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            Limpiar();
            cboCliente.Enabled = true;
            btnClienteNuevo.Enabled=true;
            btnModifyReserva.Visible = true;
            btnDeleteReserva.Visible = true;
            btnCanc.Visible = false;
            alquilerModificadoId = 0;
            title.Text = "Registro de alquiler de salas";
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

                    alquilerManager.Borrar(id.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRadioButton();
            label10.Text = "TOTAL : $ 0000.000";
        }

        private void dateTimePicker1_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarRadioButton();
            CargarComboSala();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cerrar formulario
            this.Close();
        }
    }
}
