namespace UI.Forms
{
    partial class frmAlquilerInstrumento
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
            this.label7 = new System.Windows.Forms.Label();
            this.cboPago = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClienteNuevo = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModifyReserva = new System.Windows.Forms.Button();
            this.btnDeleteReserva = new System.Windows.Forms.Button();
            this.btnAddReserva = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInstrumentos = new System.Windows.Forms.ComboBox();
            this.dataGPreview = new System.Windows.Forms.DataGridView();
            this.IdInstrumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreInstrumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.dataGAlquileres = new System.Windows.Forms.DataGridView();
            this.IdAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instrumentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 471);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 16);
            this.label7.TabIndex = 102;
            this.label7.Text = "Seleccione metodo de pago";
            // 
            // cboPago
            // 
            this.cboPago.FormattingEnabled = true;
            this.cboPago.Location = new System.Drawing.Point(217, 470);
            this.cboPago.Margin = new System.Windows.Forms.Padding(2);
            this.cboPago.Name = "cboPago";
            this.cboPago.Size = new System.Drawing.Size(242, 21);
            this.cboPago.TabIndex = 101;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 493);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "TOTAL : $";
            // 
            // btnClienteNuevo
            // 
            this.btnClienteNuevo.Location = new System.Drawing.Point(485, 372);
            this.btnClienteNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnClienteNuevo.Name = "btnClienteNuevo";
            this.btnClienteNuevo.Size = new System.Drawing.Size(85, 40);
            this.btnClienteNuevo.TabIndex = 98;
            this.btnClienteNuevo.Text = "Registrar nuevo cliente";
            this.btnClienteNuevo.UseVisualStyleBackColor = true;
            this.btnClienteNuevo.Click += new System.EventHandler(this.btnClienteNuevo_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(243, 20);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(255, 20);
            this.title.TabIndex = 96;
            this.title.Text = "Registro Alquiler de Instrumentos";
            // 
            // btnCanc
            // 
            this.btnCanc.Location = new System.Drawing.Point(247, 520);
            this.btnCanc.Margin = new System.Windows.Forms.Padding(2);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 24);
            this.btnCanc.TabIndex = 94;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.UseVisualStyleBackColor = true;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(405, 520);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(74, 24);
            this.btnSalir.TabIndex = 93;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 92;
            this.label6.Text = "Visualizador de todos los alquileres";
            // 
            // btnModifyReserva
            // 
            this.btnModifyReserva.Location = new System.Drawing.Point(711, 471);
            this.btnModifyReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnModifyReserva.Name = "btnModifyReserva";
            this.btnModifyReserva.Size = new System.Drawing.Size(82, 24);
            this.btnModifyReserva.TabIndex = 91;
            this.btnModifyReserva.Text = "Modificar";
            this.btnModifyReserva.UseVisualStyleBackColor = true;
            this.btnModifyReserva.Click += new System.EventHandler(this.btnModifyReserva_Click);
            // 
            // btnDeleteReserva
            // 
            this.btnDeleteReserva.Location = new System.Drawing.Point(836, 471);
            this.btnDeleteReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteReserva.Name = "btnDeleteReserva";
            this.btnDeleteReserva.Size = new System.Drawing.Size(75, 24);
            this.btnDeleteReserva.TabIndex = 90;
            this.btnDeleteReserva.Text = "Borrar";
            this.btnDeleteReserva.UseVisualStyleBackColor = true;
            this.btnDeleteReserva.Click += new System.EventHandler(this.btnDeleteReserva_Click);
            // 
            // btnAddReserva
            // 
            this.btnAddReserva.Location = new System.Drawing.Point(97, 520);
            this.btnAddReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddReserva.Name = "btnAddReserva";
            this.btnAddReserva.Size = new System.Drawing.Size(80, 24);
            this.btnAddReserva.TabIndex = 89;
            this.btnAddReserva.Text = "Guardar";
            this.btnAddReserva.UseVisualStyleBackColor = true;
            this.btnAddReserva.Click += new System.EventHandler(this.btnAddReserva_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(219, 429);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(240, 33);
            this.txtDesc.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 432);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 85;
            this.label5.Text = "Descripcion (opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Escoger fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "DD/MM/YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(193, 20);
            this.dateTimePicker1.TabIndex = 83;
            this.dateTimePicker1.Value = new System.DateTime(2024, 3, 6, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 383);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Seleccione un cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(219, 383);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(240, 21);
            this.cboCliente.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Seleccione el/los instrumentos";
            // 
            // cboInstrumentos
            // 
            this.cboInstrumentos.FormattingEnabled = true;
            this.cboInstrumentos.Location = new System.Drawing.Point(258, 66);
            this.cboInstrumentos.Margin = new System.Windows.Forms.Padding(2);
            this.cboInstrumentos.Name = "cboInstrumentos";
            this.cboInstrumentos.Size = new System.Drawing.Size(188, 21);
            this.cboInstrumentos.TabIndex = 103;
            this.cboInstrumentos.SelectedIndexChanged += new System.EventHandler(this.cboInstrumentos_SelectedIndexChanged);
            // 
            // dataGPreview
            // 
            this.dataGPreview.AllowUserToAddRows = false;
            this.dataGPreview.AllowUserToDeleteRows = false;
            this.dataGPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGPreview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdInstrumento,
            this.NombreInstrumento,
            this.PrecioAlquiler});
            this.dataGPreview.Location = new System.Drawing.Point(36, 127);
            this.dataGPreview.Margin = new System.Windows.Forms.Padding(2);
            this.dataGPreview.MultiSelect = false;
            this.dataGPreview.Name = "dataGPreview";
            this.dataGPreview.ReadOnly = true;
            this.dataGPreview.RowHeadersVisible = false;
            this.dataGPreview.RowHeadersWidth = 51;
            this.dataGPreview.RowTemplate.Height = 24;
            this.dataGPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGPreview.ShowCellErrors = false;
            this.dataGPreview.ShowEditingIcon = false;
            this.dataGPreview.ShowRowErrors = false;
            this.dataGPreview.Size = new System.Drawing.Size(438, 206);
            this.dataGPreview.TabIndex = 104;
            // 
            // IdInstrumento
            // 
            this.IdInstrumento.HeaderText = "IdInstrumento";
            this.IdInstrumento.Name = "IdInstrumento";
            this.IdInstrumento.ReadOnly = true;
            // 
            // NombreInstrumento
            // 
            this.NombreInstrumento.HeaderText = "NombreInstrumento";
            this.NombreInstrumento.Name = "NombreInstrumento";
            this.NombreInstrumento.ReadOnly = true;
            // 
            // PrecioAlquiler
            // 
            this.PrecioAlquiler.HeaderText = "PrecioAlquiler";
            this.PrecioAlquiler.Name = "PrecioAlquiler";
            this.PrecioAlquiler.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(216, 17);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 24);
            this.btnAdd.TabIndex = 105;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 103);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Vista previa de instrumentos a alquilar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(14, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 56);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(247, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 52);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(112, 337);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(141, 24);
            this.btnRemove.TabIndex = 109;
            this.btnRemove.Text = "Quitar Instrumento";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(336, 493);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 110;
            this.lblTotal.Text = "0";
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(262, 336);
            this.btnClean.Margin = new System.Windows.Forms.Padding(2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(161, 24);
            this.btnClean.TabIndex = 111;
            this.btnClean.Text = "Limpiar lista de Instrumento";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGAlquileres
            // 
            this.dataGAlquileres.AllowUserToAddRows = false;
            this.dataGAlquileres.AllowUserToDeleteRows = false;
            this.dataGAlquileres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGAlquileres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGAlquileres.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGAlquileres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAlquiler,
            this.Fecha,
            this.Cliente,
            this.DNI,
            this.Instrumentos,
            this.Descripcion,
            this.MetodoDePago,
            this.MontoTotal});
            this.dataGAlquileres.Location = new System.Drawing.Point(612, 55);
            this.dataGAlquileres.Margin = new System.Windows.Forms.Padding(2);
            this.dataGAlquileres.MultiSelect = false;
            this.dataGAlquileres.Name = "dataGAlquileres";
            this.dataGAlquileres.ReadOnly = true;
            this.dataGAlquileres.RowHeadersVisible = false;
            this.dataGAlquileres.RowHeadersWidth = 51;
            this.dataGAlquileres.RowTemplate.Height = 24;
            this.dataGAlquileres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGAlquileres.ShowCellErrors = false;
            this.dataGAlquileres.ShowEditingIcon = false;
            this.dataGAlquileres.ShowRowErrors = false;
            this.dataGAlquileres.Size = new System.Drawing.Size(455, 407);
            this.dataGAlquileres.TabIndex = 112;
            // 
            // IdAlquiler
            // 
            this.IdAlquiler.HeaderText = "IdAlquiler";
            this.IdAlquiler.Name = "IdAlquiler";
            this.IdAlquiler.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Instrumentos
            // 
            this.Instrumentos.HeaderText = "Instrumentos";
            this.Instrumentos.Name = "Instrumentos";
            this.Instrumentos.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // MetodoDePago
            // 
            this.MetodoDePago.HeaderText = "MetodoDePago";
            this.MetodoDePago.Name = "MetodoDePago";
            this.MetodoDePago.ReadOnly = true;
            // 
            // MontoTotal
            // 
            this.MontoTotal.HeaderText = "MontoTotal";
            this.MontoTotal.Name = "MontoTotal";
            this.MontoTotal.ReadOnly = true;
            // 
            // frmAlquilerInstrumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 555);
            this.Controls.Add(this.dataGAlquileres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGPreview);
            this.Controls.Add(this.cboInstrumentos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPago);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClienteNuevo);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnModifyReserva);
            this.Controls.Add(this.btnDeleteReserva);
            this.Controls.Add(this.btnAddReserva);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmAlquilerInstrumento";
            this.Text = "frmAlquilerInstrumento";
            this.Load += new System.EventHandler(this.frmAlquilerInstrumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGAlquileres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClienteNuevo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModifyReserva;
        private System.Windows.Forms.Button btnDeleteReserva;
        private System.Windows.Forms.Button btnAddReserva;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboInstrumentos;
        private System.Windows.Forms.DataGridView dataGPreview;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdInstrumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreInstrumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioAlquiler;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.DataGridView dataGAlquileres;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instrumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotal;
    }
}