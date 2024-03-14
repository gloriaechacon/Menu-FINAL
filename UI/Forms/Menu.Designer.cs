namespace UI
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarRolesYPermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alquileresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeInformesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administracionToolStripMenuItem,
            this.alquileresToolStripMenuItem1,
            this.localToolStripMenuItem,
            this.gestionDeInformesToolStripMenuItem,
            this.seguridadToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarUsuariosToolStripMenuItem,
            this.administrarRolesYPermisosToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // administrarUsuariosToolStripMenuItem
            // 
            this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
            this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
            this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // administrarRolesYPermisosToolStripMenuItem
            // 
            this.administrarRolesYPermisosToolStripMenuItem.Name = "administrarRolesYPermisosToolStripMenuItem";
            this.administrarRolesYPermisosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.administrarRolesYPermisosToolStripMenuItem.Text = "Administrar Roles y Permisos";
            this.administrarRolesYPermisosToolStripMenuItem.Click += new System.EventHandler(this.administrarRolesYPermisosToolStripMenuItem_Click);
            // 
            // alquileresToolStripMenuItem1
            // 
            this.alquileresToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salasToolStripMenuItem1,
            this.instrumentosToolStripMenuItem1,
            this.registrarClientesToolStripMenuItem});
            this.alquileresToolStripMenuItem1.Name = "alquileresToolStripMenuItem1";
            this.alquileresToolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.alquileresToolStripMenuItem1.Text = "Alquileres";
            // 
            // salasToolStripMenuItem1
            // 
            this.salasToolStripMenuItem1.Name = "salasToolStripMenuItem1";
            this.salasToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.salasToolStripMenuItem1.Text = "Salas";
            this.salasToolStripMenuItem1.Click += new System.EventHandler(this.salasToolStripMenuItem1_Click);
            // 
            // instrumentosToolStripMenuItem1
            // 
            this.instrumentosToolStripMenuItem1.Name = "instrumentosToolStripMenuItem1";
            this.instrumentosToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.instrumentosToolStripMenuItem1.Text = "Instrumentos";
            this.instrumentosToolStripMenuItem1.Click += new System.EventHandler(this.instrumentosToolStripMenuItem1_Click);
            // 
            // registrarClientesToolStripMenuItem
            // 
            this.registrarClientesToolStripMenuItem.Name = "registrarClientesToolStripMenuItem";
            this.registrarClientesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.registrarClientesToolStripMenuItem.Text = "Registrar Clientes";
            this.registrarClientesToolStripMenuItem.Click += new System.EventHandler(this.registrarClientesToolStripMenuItem_Click);
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salasToolStripMenuItem,
            this.instrumentosToolStripMenuItem});
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.localToolStripMenuItem.Text = "Gestion";
            // 
            // salasToolStripMenuItem
            // 
            this.salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            this.salasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.salasToolStripMenuItem.Text = "ABM Salas";
            this.salasToolStripMenuItem.Click += new System.EventHandler(this.salasToolStripMenuItem_Click);
            // 
            // instrumentosToolStripMenuItem
            // 
            this.instrumentosToolStripMenuItem.Name = "instrumentosToolStripMenuItem";
            this.instrumentosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.instrumentosToolStripMenuItem.Text = "ABM Instrumentos";
            this.instrumentosToolStripMenuItem.Click += new System.EventHandler(this.instrumentosToolStripMenuItem_Click);
            // 
            // gestionDeInformesToolStripMenuItem
            // 
            this.gestionDeInformesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashBoardToolStripMenuItem});
            this.gestionDeInformesToolStripMenuItem.Name = "gestionDeInformesToolStripMenuItem";
            this.gestionDeInformesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.gestionDeInformesToolStripMenuItem.Text = "Informes";
            // 
            // dashBoardToolStripMenuItem
            // 
            this.dashBoardToolStripMenuItem.Name = "dashBoardToolStripMenuItem";
            this.dashBoardToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.dashBoardToolStripMenuItem.Text = "DashBoard";
            this.dashBoardToolStripMenuItem.Click += new System.EventHandler(this.dashBoardToolStripMenuItem_Click);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpRestoreToolStripMenuItem});
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // backUpRestoreToolStripMenuItem
            // 
            this.backUpRestoreToolStripMenuItem.Name = "backUpRestoreToolStripMenuItem";
            this.backUpRestoreToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.backUpRestoreToolStripMenuItem.Text = "BackUp - Restore";
            this.backUpRestoreToolStripMenuItem.Click += new System.EventHandler(this.backUpRestoreToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(999, 483);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alquileresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem instrumentosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeInformesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarRolesYPermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}

