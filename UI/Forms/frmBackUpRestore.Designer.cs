namespace UI.Forms
{
    partial class frmBackUpRestore
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
            this.dataGBackup = new System.Windows.Forms.DataGridView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.BackUps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGBackup
            // 
            this.dataGBackup.AllowUserToAddRows = false;
            this.dataGBackup.AllowUserToDeleteRows = false;
            this.dataGBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGBackup.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BackUps});
            this.dataGBackup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGBackup.Location = new System.Drawing.Point(329, 49);
            this.dataGBackup.Margin = new System.Windows.Forms.Padding(2);
            this.dataGBackup.MultiSelect = false;
            this.dataGBackup.Name = "dataGBackup";
            this.dataGBackup.ReadOnly = true;
            this.dataGBackup.RowHeadersVisible = false;
            this.dataGBackup.RowHeadersWidth = 51;
            this.dataGBackup.RowTemplate.Height = 24;
            this.dataGBackup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGBackup.Size = new System.Drawing.Size(361, 305);
            this.dataGBackup.TabIndex = 57;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(133, 137);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(100, 41);
            this.btnRestore.TabIndex = 58;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(133, 67);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(100, 43);
            this.btnBackup.TabIndex = 59;
            this.btnBackup.Text = "Realizar BackUp";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(133, 249);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 37);
            this.btnSalir.TabIndex = 60;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BackUps
            // 
            this.BackUps.HeaderText = "BackUps";
            this.BackUps.Name = "BackUps";
            this.BackUps.ReadOnly = true;
            // 
            // frmBackUpRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.dataGBackup);
            this.Name = "frmBackUpRestore";
            this.Text = "frmBackUpRestore";
            ((System.ComponentModel.ISupportInitialize)(this.dataGBackup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackUps;
    }
}