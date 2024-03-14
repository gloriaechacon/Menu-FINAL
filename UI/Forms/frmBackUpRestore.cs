using BL;
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
    public partial class frmBackUpRestore : Form
    {
        BackUpManager backUpManager;
        public frmBackUpRestore()
        {
            InitializeComponent();
            backUpManager = new BackUpManager();
            CargarData();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                bool backUp = backUpManager.BackUp(DateTime.Now);
                CargarData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CargarData()
        {
            this.dataGBackup.DataSource = null;
            this.dataGBackup.Rows.Clear();
            var lista = backUpManager.Listar();
            if(lista.Count == 0)
            {
                btnRestore.Enabled = false;
            }
            else
            {
                foreach( var item in lista) {
                    dataGBackup.Rows.Add(item);             
                }
                btnRestore.Enabled = true;
            }
            
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string archivo = dataGBackup.SelectedCells[0].Value.ToString();
                bool backUp = backUpManager.Restore(archivo);
                CargarData();
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
    }
}
