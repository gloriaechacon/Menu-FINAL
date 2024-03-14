using BE;
using BL;
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
    public partial class frmAltaCliente : Form
    {
        ClienteManager clienteManager;
        Cliente cliente;
        bool register;

        public frmAltaCliente()
        {
            InitializeComponent();
            cliente = new Cliente();
            clienteManager = new ClienteManager();
            CargarData();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var hasMinChars = new Regex(@".{7,}");
                var validDni = new Regex(@"^(\d{7,8})$");
                var validPassword = new Regex(@"^(\d{5})$");

                //Al presionar el botón aceptar valido que los datos ingresados sean correctos
                if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtDireccion.Text == string.Empty || txtDni.Text == string.Empty || txtTelefono.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else if (!hasMinChars.IsMatch(txtDni.Text))
                {
                    MessageBox.Show("El DNI no tiene la longitud correcta");
                }
                else if (!validDni.IsMatch(txtDni.Text))
                {
                    MessageBox.Show("DNI invalido");
                }
                else if (clienteManager.ExisteDni(txtDni.Text))
                {
                    MessageBox.Show("Ya existe un usuario registrado con este dni");
                }
                else
                {
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.DNI = Convert.ToInt32(txtDni.Text);
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;

                    register = clienteManager.AltaCliente(cliente);
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
                if (register == true)
                {
                    this.DialogResult = DialogResult.OK;
                    CargarData();
                    Limpiar();
                    MessageBox.Show("¡Operación exitosa!");
                    this.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Cerrar formulario
            this.Close();
        }

        void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
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

        private void frmAltaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
