using BE;
using BL;
using Servicio;
using System;
using System.Collections;
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
    public partial class frmUsuario : Form
    {
        Usuario usuario = new Usuario();
        UsuarioManager usuarioManager;
        Rol rol = new Rol();
        RolManager rolManager;
        bool register;
        int usuarioModificadoId;

        public frmUsuario()
        {
            InitializeComponent();
            usuarioManager = new UsuarioManager();
            rolManager = new RolManager();
            usuarioModificadoId = 0;
            btnCancel.Visible = false;
            CargarData();
            CargarCombo();
        }

        void CargarCombo()
        {
            cboRol.DataSource = null;
            cboRol.DataSource = rolManager.Listar();
            cboRol.ValueMember = "Id";
            cboRol.DisplayMember = "Nombre";
            cboRol.Refresh();
            cboRol.SelectedItem = null;
        }
        void CargarData()
        {
            this.dataGUsuario.DataSource = null;
            this.dataGUsuario.Rows.Clear();
            var query = usuarioManager.Listar();
            if (query != null)
            {
                foreach (var User in query)
                {
                    dataGUsuario.Rows.Add(
                        User.Id,
                        User.Nombre,
                        User.Apellido,
                        User.DNI,
                        User.Username,
                        User.Rol.Nombre);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var hasMinChars = new Regex(@".{7,}");
                var validDni = new Regex(@"^(\d{7,8})$");
                var validPassword = new Regex(@"^(\d{5})$");

                //Al presionar el botón aceptar valido que los datos ingresados sean correctos
                if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtClave.Text == string.Empty || txtDNI.Text == string.Empty || txtUsername.Text == string.Empty || txtRepetir.Text == string.Empty)
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
                else if (usuarioManager.ExisteUsuario(txtUsername.Text) && usuarioModificadoId == 0)
                {
                    MessageBox.Show("Ya existe el nombre de usuario ingresado. Ingrese otro.");
                }
                else if (txtClave.Text != txtRepetir.Text)
                {
                    MessageBox.Show("Las contraseñas deben coincidir");
                }
                else if (!validPassword.IsMatch(txtClave.Text))
                {
                    MessageBox.Show("Contraseña invalida");
                }
                else
                {
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.DNI = Convert.ToInt32(txtDNI.Text);
                    usuario.Username = txtUsername.Text;
                    usuario.Clave = Encriptacion.Encriptar(txtClave.Text);
                    usuario.Rol = (Rol)cboRol.SelectedItem;
                    //Si el usuario va a ser modificado, guardo el Id en mi objeto
                    if (usuarioModificadoId != 0)
                    {
                        usuario.DNI = Convert.ToInt32(txtDNI.Text);
                        usuario.Id = usuarioModificadoId;
                        btnModificar.Visible = true;
                        btnBorrar.Visible = true;
                        btnCancel.Visible = false;
                        usuarioModificadoId = 0;
                    }
                    else
                    {
                        if (usuarioManager.ExisteDni(txtDNI.Text))
                        {
                            throw new Exception("Ya existe un cliente registrado con este dni");
                        }
                        else
                        {
                            usuario.DNI = Convert.ToInt32(txtDNI.Text);
                        }
                    }
                    register = usuarioManager.Guardar(usuario);
                    
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
                //De lo contrario, indico que hubo un error y dejo el formulario abierto para que el usuario lo cierre
                if (register == true)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("¡Operación exitosa!");
                    register = false;
                    usuario = new Usuario();
                    CargarCombo();
                    CargarData();
                    Limpiar();
                }
            }
        }

        void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtRepetir.Text = string.Empty;
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarCombo();
            btnModificar.Visible = true;
            btnBorrar.Visible = true;
            btnCancel.Visible = false;
            usuarioModificadoId = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                txtNombre.Text = (string)this.dataGUsuario.SelectedRows[0].Cells["Nombre"].Value;
                txtApellido.Text = (string)this.dataGUsuario.SelectedRows[0].Cells["Apellido"].Value;
                txtDNI.Text = this.dataGUsuario.SelectedRows[0].Cells["DNI"].Value.ToString();
                txtUsername.Text = (string)this.dataGUsuario.SelectedRows[0].Cells["Username"].Value;
                usuarioModificadoId = (int)this.dataGUsuario.SelectedRows[0].Cells["Id"].Value;
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
                if (dataGUsuario.Rows.Count == 0) throw new Exception("No hay usuarios para borrar");
                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    int id = (int)this.dataGUsuario.SelectedRows[0].Cells["Id"].Value;

                    usuarioManager.Borrar(id.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            usuario.Id = (int)this.dataGUsuario.SelectedRows[0].Cells["Id"].Value;
            usuario.Username = (string)this.dataGUsuario.SelectedRows[0].Cells["Username"].Value;
            var clave = Encriptacion.Desencriptar(usuarioManager.ObtenerClave(usuario.Id));
            MessageBox.Show($"La contraseña del usuario {usuario.Username} es {clave}");
            Bitacora.Evento($"El usuario {ApplicationGlobalContext.Instance.Usuario.Username} desencripto la contraseña del usuario {usuario.Username}");
        }

        private void frmUsuario_Activated(object sender, EventArgs e)
        { 
        }

        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
