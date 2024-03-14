using BE;
using BL;
using Microsoft.Win32;
using Servicio;
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
using System.Xml.Linq;

namespace UI.Forms
{
    public partial class frmPermisos : Form
    {
        RolManager rolManager;
        Rol rol;
        PermisoManager permisoManager;
        Permiso permiso;
        RolPermiso rolPermiso;
        UsuarioManager usuarioManager;
        RolPermisoManager rolPermisoManager;
        bool alta;

        public frmPermisos()
        {
            InitializeComponent();
            rolManager = new RolManager();
            rol =  new Rol();
            permiso = new Permiso();
            permisoManager  = new PermisoManager();
            usuarioManager = new UsuarioManager();
            rolPermiso  = new RolPermiso();
            rolPermisoManager = new RolPermisoManager();
            CargarCombo();
            CargarData();
            CargarCheckBox();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese el nombre del rol");
                }
                else
                {
                    rol.Nombre = txtNombre.Text;
                    alta = rolManager.AltaRol(rol);
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
                if (alta == true)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("¡Operación exitosa!");
                    CargarData();
                    CheckBoxClear();
                    alta = false;
                    Limpiar();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGRoles.Rows.Count == 0) throw new Exception("No hay roles para borrar");

                int rolId = (int)this.dataGRoles.SelectedRows[0].Cells["Id"].Value;
                if (rolId == 1)
                {
                    throw new Exception("No puede dar de baja al rol de administrador");
                }

                var existeAlquiler = usuarioManager.ExisteRolUsuario(rolId);

                if (existeAlquiler)
                {
                    throw new Exception("Error: Rol asociado a un usuario");
                }

                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    rolManager.Borrar(rolId.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }
        void CargarData()
        {
            this.dataGRoles.DataSource = null;
            //Guardo en una variable la lista de salas y las paso a la grilla
            this.dataGRoles.DataSource = rolManager.Listar();
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

        void CargarCheckBox()
        {
           var permisos = permisoManager.Listar();
            checkedPermisos.DataSource = permisos;
            checkedPermisos.ValueMember = "Id";
            checkedPermisos.DisplayMember = "Nombre";
            checkedPermisos.Refresh();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var rolSeleccionado = (Rol)cboRol.SelectedItem;
                var listaPermisos = new List<int>();

                for (int i = 0; i < checkedPermisos.CheckedItems.Count; i++)
                {
                    var value = (Permiso)checkedPermisos.CheckedItems[i];
                    listaPermisos.Add(value.Id);
                }
                rolPermisoManager.ActualizarPermisos(rolSeleccionado.Id, listaPermisos);
                MessageBox.Show("Operacion exitosa");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxClear();
        }

        void CheckBoxClear()
        {
            if (cboRol.SelectedItem != null)
            {
                var rolSeleccionado = (Rol)cboRol.SelectedItem;
                var permisos = rolPermisoManager.ListarRelacion(rolSeleccionado.Id).Select(x => x.PermisoId);
                for (int i = 0; i < checkedPermisos.Items.Count; i++)
                {
                    var value = (Permiso)checkedPermisos.Items[i];
                    checkedPermisos.SetItemChecked(i, permisos.Contains(value.Id));
                }
            }
            else
            {
                for (int i = 0; i < checkedPermisos.Items.Count; i++)
                {
                    var value = (Permiso)checkedPermisos.Items[i];
                    checkedPermisos.SetItemChecked(i, false);
                }
            }
        }
    }
}
