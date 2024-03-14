using BE;
using BL;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmLogin : Form
    {
        Usuario usuario;
        UsuarioManager usuarioManager;
        bool log;
        public frmLogin()
        {
            InitializeComponent();
            usuario = new Usuario();
            usuarioManager = new UsuarioManager();

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                //Al presionar el botón aceptar valido que los datos ingresados sean correctos
                if (txtUser.Text == string.Empty || txtPassw.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else
                {
                    usuario.Username = txtUser.Text;
                    usuario.Clave = Encriptacion.Encriptar(txtPassw.Text);
                    usuarioManager.Loguear(usuario);
                }
            }
            catch (Exception ex)
            {
                //En caso de que ocurra una excepción muestro el cartel de error.
                MessageBox.Show("Ha ocurrido un error. Usuario o contraseña incorrecto, verifique los datos. Detalle: " + ex.Message);
            }
            finally
            {
                //Llegado a este punto seteo el resultado de la operación como OK si los datos son validos y cierro el formulario.
                //De lo contrario, indico que hubo un error y dejo el formulario abierto para que el usuario lo cierre
                if (ApplicationGlobalContext.Instance.Usuario != null)
                {
                    this.DialogResult = DialogResult.OK;
                    Menu frm = new Menu();
                    txtUser.Clear();
                    txtPassw.Clear();
                    this.Hide();
                    frm.ShowDialog();
                    ApplicationGlobalContext.Instance.Usuario = null;
                    this.Show();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //Cerrar formulario
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
