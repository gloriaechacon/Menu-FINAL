using BE;
using BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmCliente : Form
    {
        ClienteManager clienteManager;
        Cliente cliente;
        bool register;
        int clienteModificadoId = 0;

        public frmCliente()
        {
            InitializeComponent();
            cliente = new Cliente();
            clienteManager = new ClienteManager();
            CargarData();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var hasMinChars = new Regex(@".{7,}");
                var validDni = new Regex(@"^(\d{7,8})$");
                var validPassword = new Regex(@"^(\d{5})$");

                //Al presionar el botón aceptar valido que los datos ingresados sean correctos
                if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtDireccion.Text == string.Empty || txtDNI.Text == string.Empty || txtTelefono.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else if (!hasMinChars.IsMatch(txtDNI.Text))
                {
                    MessageBox.Show("El DNI no tiene la longitud correcta");
                }
                else if (!validDni.IsMatch(txtDNI.Text))
                {
                    MessageBox.Show("DNI invalido");
                }
                else if (clienteManager.ExisteDni(txtDNI.Text) && clienteModificadoId == 0)
                {
                    MessageBox.Show("Ya existe un cliente registrado con este dni");
                }
                else
                {
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.DNI = Convert.ToInt32(txtDNI.Text);
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;

                    //Si el cliente va a ser modificado, guardo el Id en mi objeto
                    if (clienteModificadoId != 0)
                    {
                        cliente.DNI = Convert.ToInt32(txtDNI.Text);
                        cliente.Id = clienteModificadoId;
                        btnModificar.Visible = true;
                        btnBorrar.Visible = true;
                        btnCancel.Visible = false;
                        clienteModificadoId = 0;
                    }
                    else
                    {
                        if (clienteManager.ExisteDni(txtDNI.Text))
                        {
                            throw new Exception("Ya existe un cliente registrado con este dni");
                        }
                        else
                        {
                            cliente.DNI = Convert.ToInt32(txtDNI.Text);
                        }
                    }

                    register = clienteManager.Guardar(cliente);
                    
                }
            }
            catch (Exception ex)
            {
                //En caso de que ocurra una excepción muestro el cartel de error.
                MessageBox.Show("Ha ocurrido un error. Detalle: " + ex.Message);
                register = false;
            }
            finally
            {
                //Llegado a este punto seteo el resultado de la operación como OK si los datos son validos y cierro el formulario.
                //De lo contrario, indico que hubo un error y dejo el formulario abierto para que el cliente lo cierre
                if (register == true)
                {
                    this.DialogResult = DialogResult.OK;
                    CargarData();
                    Limpiar();
                    register = false;
                    MessageBox.Show("¡Operación exitosa!");
                    cliente = new Cliente();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnModificar.Visible = true;
            btnBorrar.Visible = true;
            btnCancel.Visible = false;
            clienteModificadoId = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                txtNombre.Text = (string)this.dataGCliente.SelectedRows[0].Cells["Nombre"].Value;
                txtApellido.Text = (string)this.dataGCliente.SelectedRows[0].Cells["Apellido"].Value;
                txtDNI.Text = this.dataGCliente.SelectedRows[0].Cells["DNI"].Value.ToString();
                clienteModificadoId = (int)this.dataGCliente.SelectedRows[0].Cells["Id"].Value;
                txtDireccion.Text = (string)this.dataGCliente.SelectedRows[0].Cells["Direccion"].Value;
                txtTelefono.Text = (string)this.dataGCliente.SelectedRows[0].Cells["Telefono"].Value;
                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGCliente.Rows.Count == 0) throw new Exception("No hay clientes para borrar");

                int clienteId = (int)this.dataGCliente.SelectedRows[0].Cells["Id"].Value;
                var existeAlquilerInstrumento = clienteManager.ExisteAlquilerInstrumento(clienteId);
                var existeAlquilerSala = clienteManager.ExisteAlquilerSala(clienteId);

                if (existeAlquilerInstrumento || existeAlquilerSala)
                {
                    throw new Exception("Error: No puede eliminar un cliente asociado a un alquiler");
                }

                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el cliente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    int id = (int)this.dataGCliente.SelectedRows[0].Cells["Id"].Value;

                    clienteManager.Borrar(id.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        void CargarData()
        {
            this.dataGCliente.DataSource = null;
            this.dataGCliente.Rows.Clear();
            var query = clienteManager.Listar();
            if (query != null)
            {
                foreach (var User in query)
                {
                    dataGCliente.Rows.Add(
                        User.Id,
                        User.Nombre,
                        User.Apellido,
                        User.DNI,
                        User.Direccion,
                        User.Telefono);
                }
            }
        }
    }
}
