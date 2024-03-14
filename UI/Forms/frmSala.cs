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
    public partial class frmSala : Form
    {
        int salaModificadaId;
        Sala sala;
        SalaManager salaManager;
        bool guardar;
        public frmSala()
        {
            InitializeComponent();
            salaModificadaId = 0;
            salaManager = new SalaManager();
            sala = new Sala();
            btnCancel.Visible = false;
            CargarData();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var hasMinChars = new Regex(@".{7,}");
                var validDni = new Regex(@"^(\d{7,8})$");
                var validPassword = new Regex(@"^(\d{5})$");
                var codigoCorrecto = new Regex(@"[a-z]{2}[0-9]{3}");


                //Al presionar el botón aceptar valido que los datos ingresados sean correctos
                if (txtNombre.Text == string.Empty || txtCodigo.Text == string.Empty || txtPrecio.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese todos los campos");
                }
                else if (!codigoCorrecto.IsMatch(txtCodigo.Text))
                {
                    throw new Exception("Codigo invalido");
                }
                else
                {
                    sala.Nombre = txtNombre.Text;
                    sala.Codigo = txtCodigo.Text;
                    sala.Descripcion = txtDescripcion.Text;
                    sala.Precio = Convert.ToDouble(txtPrecio.Text);
                    //Si la sala va a ser modificada, guardo el Id en mi objeto
                    if (salaModificadaId != 0)
                    {
                        sala.Id = salaModificadaId;
                        btnModificar.Visible = true;
                        btnBorrar.Visible = true;
                        btnCancel.Visible = false;
                        salaModificadaId = 0;
                    }
                    //Llamo al metodo Guardar de la sala y le paso el objeto
                    guardar = salaManager.Guardar(sala);
                    //Actualizo la grilla
                    CargarData();
                    //Limpio los campos del textbox
                    Limpiar();
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
                if (guardar == true)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("¡Operación exitosa!");
                    sala = new Sala();
                    guardar = false;
                    CargarData();
                    Limpiar();
                }
            }
        }
        void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        void CargarData()
        {
            this.dataGSala.DataSource = null;
            this.dataGSala.Rows.Clear();
            var query = salaManager.Listar();
            if (query != null)
            {
                foreach (var User in query)
                {
                    dataGSala.Rows.Add(
                        User.Id,
                        User.Nombre,
                        User.Codigo,
                        User.Descripcion,
                        User.Precio);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnModificar.Visible = true;
            btnBorrar.Visible = true;
            btnCancel.Visible = false;
            salaModificadaId = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                txtNombre.Text = (string)this.dataGSala.SelectedRows[0].Cells["Nombre"].Value;
                txtDescripcion.Text = (string)this.dataGSala.SelectedRows[0].Cells["Descripcion"].Value;
                txtCodigo.Text = (string)this.dataGSala.SelectedRows[0].Cells["Codigo"].Value;
                txtPrecio.Text = this.dataGSala.SelectedRows[0].Cells["Precio"].Value.ToString();
                salaModificadaId = (int)this.dataGSala.SelectedRows[0].Cells["IdSala"].Value;
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
                if (dataGSala.Rows.Count == 0) throw new Exception("No hay salas para borrar");

                int salaId = (int)this.dataGSala.SelectedRows[0].Cells["IdSala"].Value;
                var existeAlquiler = salaManager.ExisteAlquiler(salaId);

                if(existeAlquiler)
                {
                    throw new Exception("La sala que intenta borrar esta asociada a un alquiler, asigne otra sala al alquiler antes de borrar esta");
                }

                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    salaManager.Borrar(salaId.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
