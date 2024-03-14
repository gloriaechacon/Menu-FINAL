namespace UI.Forms
{
    partial class frmAlquilerSala
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
            this.label10 = new System.Windows.Forms.Label();
            this.btnClienteNuevo = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.dataGAlquileres = new System.Windows.Forms.DataGridView();
            this.IdAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioAfternoon = new System.Windows.Forms.RadioButton();
            this.radioNoon = new System.Windows.Forms.RadioButton();
            this.radioMorning = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cboPago = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGAlquileres)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "TOTAL : $ 0000.000";
            // 
            // btnClienteNuevo
            // 
            this.btnClienteNuevo.Location = new System.Drawing.Point(434, 209);
            this.btnClienteNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnClienteNuevo.Name = "btnClienteNuevo";
            this.btnClienteNuevo.Size = new System.Drawing.Size(94, 34);
            this.btnClienteNuevo.TabIndex = 72;
            this.btnClienteNuevo.Text = "Registrar nuevo cliente";
            this.btnClienteNuevo.UseVisualStyleBackColor = true;
            this.btnClienteNuevo.Click += new System.EventHandler(this.btnClienteNuevo_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(272, 19);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(195, 20);
            this.title.TabIndex = 70;
            this.title.Text = "Registro Alquiler de Salas";
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
            this.Hora,
            this.Cliente,
            this.DNI,
            this.CodigoSala,
            this.NombreSala,
            this.Descripcion,
            this.MetodoDePago,
            this.Total});
            this.dataGAlquileres.Location = new System.Drawing.Point(544, 50);
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
            this.dataGAlquileres.Size = new System.Drawing.Size(486, 394);
            this.dataGAlquileres.TabIndex = 69;
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
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
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
            // CodigoSala
            // 
            this.CodigoSala.HeaderText = "CodigoSala";
            this.CodigoSala.Name = "CodigoSala";
            this.CodigoSala.ReadOnly = true;
            // 
            // NombreSala
            // 
            this.NombreSala.HeaderText = "NombreSala";
            this.NombreSala.Name = "NombreSala";
            this.NombreSala.ReadOnly = true;
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
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // btnCanc
            // 
            this.btnCanc.Location = new System.Drawing.Point(186, 400);
            this.btnCanc.Margin = new System.Windows.Forms.Padding(2);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(82, 24);
            this.btnCanc.TabIndex = 68;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.UseVisualStyleBackColor = true;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(333, 400);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(74, 24);
            this.btnSalir.TabIndex = 67;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Visualizador de todos los alquileres";
            // 
            // btnModifyReserva
            // 
            this.btnModifyReserva.Location = new System.Drawing.Point(671, 448);
            this.btnModifyReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnModifyReserva.Name = "btnModifyReserva";
            this.btnModifyReserva.Size = new System.Drawing.Size(82, 24);
            this.btnModifyReserva.TabIndex = 65;
            this.btnModifyReserva.Text = "Modificar";
            this.btnModifyReserva.UseVisualStyleBackColor = true;
            this.btnModifyReserva.Click += new System.EventHandler(this.btnModifyReserva_Click);
            // 
            // btnDeleteReserva
            // 
            this.btnDeleteReserva.Location = new System.Drawing.Point(795, 448);
            this.btnDeleteReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteReserva.Name = "btnDeleteReserva";
            this.btnDeleteReserva.Size = new System.Drawing.Size(75, 24);
            this.btnDeleteReserva.TabIndex = 64;
            this.btnDeleteReserva.Text = "Borrar";
            this.btnDeleteReserva.UseVisualStyleBackColor = true;
            this.btnDeleteReserva.Click += new System.EventHandler(this.btnDeleteReserva_Click);
            // 
            // btnAddReserva
            // 
            this.btnAddReserva.Location = new System.Drawing.Point(44, 400);
            this.btnAddReserva.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddReserva.Name = "btnAddReserva";
            this.btnAddReserva.Size = new System.Drawing.Size(80, 24);
            this.btnAddReserva.TabIndex = 63;
            this.btnAddReserva.Text = "Guardar";
            this.btnAddReserva.UseVisualStyleBackColor = true;
            this.btnAddReserva.Click += new System.EventHandler(this.btnAddReserva_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(171, 255);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(249, 34);
            this.txtDesc.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Descripcion (opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Escoger fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "DD/MM/YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(145, 61);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(275, 20);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.Value = new System.DateTime(2024, 2, 27, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.TabIndexChanged += new System.EventHandler(this.dateTimePicker1_TabIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Seleccione una sala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Seleccione un cliente existente";
            // 
            // cboSala
            // 
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(145, 94);
            this.cboSala.Margin = new System.Windows.Forms.Padding(2);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(275, 21);
            this.cboSala.TabIndex = 54;
            this.cboSala.SelectedIndexChanged += new System.EventHandler(this.cboSala_SelectedIndexChanged);
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(171, 217);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(249, 21);
            this.cboCliente.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioAfternoon);
            this.groupBox1.Controls.Add(this.radioNoon);
            this.groupBox1.Controls.Add(this.radioMorning);
            this.groupBox1.Location = new System.Drawing.Point(44, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 49);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione un horario";
            // 
            // radioAfternoon
            // 
            this.radioAfternoon.AutoSize = true;
            this.radioAfternoon.Location = new System.Drawing.Point(308, 19);
            this.radioAfternoon.Name = "radioAfternoon";
            this.radioAfternoon.Size = new System.Drawing.Size(52, 17);
            this.radioAfternoon.TabIndex = 2;
            this.radioAfternoon.Text = "18:00";
            this.radioAfternoon.UseVisualStyleBackColor = true;
            // 
            // radioNoon
            // 
            this.radioNoon.AutoSize = true;
            this.radioNoon.Location = new System.Drawing.Point(176, 19);
            this.radioNoon.Name = "radioNoon";
            this.radioNoon.Size = new System.Drawing.Size(52, 17);
            this.radioNoon.TabIndex = 1;
            this.radioNoon.Text = "13:00";
            this.radioNoon.UseVisualStyleBackColor = true;
            // 
            // radioMorning
            // 
            this.radioMorning.AutoSize = true;
            this.radioMorning.Location = new System.Drawing.Point(57, 19);
            this.radioMorning.Name = "radioMorning";
            this.radioMorning.Size = new System.Drawing.Size(46, 17);
            this.radioMorning.TabIndex = 0;
            this.radioMorning.Text = "9:00";
            this.radioMorning.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 317);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 16);
            this.label7.TabIndex = 77;
            this.label7.Text = "Seleccione metodo de pago";
            // 
            // cboPago
            // 
            this.cboPago.FormattingEnabled = true;
            this.cboPago.Location = new System.Drawing.Point(208, 316);
            this.cboPago.Margin = new System.Windows.Forms.Padding(2);
            this.cboPago.Name = "cboPago";
            this.cboPago.Size = new System.Drawing.Size(212, 21);
            this.cboPago.TabIndex = 76;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(186, 120);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(147, 29);
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Text = "Buscar Disponibilidad";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmAlquilerSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 495);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPago);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClienteNuevo);
            this.Controls.Add(this.title);
            this.Controls.Add(this.dataGAlquileres);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnModifyReserva);
            this.Controls.Add(this.btnDeleteReserva);
            this.Controls.Add(this.btnAddReserva);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSala);
            this.Controls.Add(this.cboCliente);
            this.Name = "frmAlquilerSala";
            this.Text = "frmAlquilerSala";
            this.Load += new System.EventHandler(this.frmAlquilerSala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGAlquileres)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClienteNuevo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView dataGAlquileres;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSala;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioAfternoon;
        private System.Windows.Forms.RadioButton radioNoon;
        private System.Windows.Forms.RadioButton radioMorning;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSala;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}