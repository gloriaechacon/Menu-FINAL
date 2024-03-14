using BE;
using BL;
using Servicio;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class Menu : Form
    {
        RolManager rolManager;
        UsuarioManager usuarioManager;
        PermisoManager permisoManager;
        public Menu()
        {
            InitializeComponent();
            rolManager = new RolManager();
            usuarioManager = new UsuarioManager();
            permisoManager = new PermisoManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var accessControl = ApplicationGlobalContext.Instance.AccessControl;
            menuStrip1.Items.Find("administracionToolStripMenuItem", true).FirstOrDefault().Visible = accessControl.TienePermisos("Administracion");
            menuStrip1.Items.Find("alquileresToolStripMenuItem1", true).FirstOrDefault().Visible = accessControl.TienePermisos("Alquileres");
            menuStrip1.Items.Find("localToolStripMenuItem", true).FirstOrDefault().Visible = accessControl.TienePermisos("Gestion");
            menuStrip1.Items.Find("gestionDeInformesToolStripMenuItem", true).FirstOrDefault().Visible = accessControl.TienePermisos("Informes");
            menuStrip1.Items.Find("seguridadToolStripMenuItem", true).FirstOrDefault().Visible = accessControl.TienePermisos("Seguridad");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void backUpRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackUpRestore frm = new frmBackUpRestore();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSala frm = new frmSala();
            frm.MdiParent = this;
            frm.Show();
        }

        private void instrumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInstrumento frm = new frmInstrumento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAlquilerSala frm = new frmAlquilerSala();
            frm.MdiParent = this;
            frm.Show();
        }

        private void instrumentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAlquilerInstrumento frm = new frmAlquilerInstrumento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInforme frm = new frmInforme();
            frm.MdiParent = this;
            frm.Show();
        }

        private void administrarPermisosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPermisos frm = new frmPermisos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void administrarRolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermisos frm = new frmPermisos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult solicitud;
            solicitud = MessageBox.Show("Cerrará la sesión actual ¿desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (solicitud == DialogResult.Yes)
            {
                ApplicationGlobalContext.Instance.AccessControl = new Composite();
                this.Close();
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationGlobalContext.Instance.AccessControl = new Composite();
        }
    }
}
