using BE.Enums;
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
    public partial class frmInstrumento : Form
    {
        int instrumentoModificadoId;
        Instrumento instrumento;
        InstrumentoManager instrumentoManager;
        bool guardar;

        public frmInstrumento()
        {
            InitializeComponent();
            instrumentoModificadoId = 0;
            instrumentoManager = new InstrumentoManager();
            instrumento = new Instrumento();
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
                    instrumento.Nombre = txtNombre.Text;
                    instrumento.Codigo = txtCodigo.Text;
                    instrumento.Descripcion = txtDescripcion.Text;
                    instrumento.Precio = Convert.ToDouble(txtPrecio.Text);
                    //Si la sala va a ser modificada, guardo el Id en mi objeto
                    if (instrumentoModificadoId != 0)
                    {
                        instrumento.Id = instrumentoModificadoId;
                        btnModificar.Visible = true;
                        btnBorrar.Visible = true;
                        btnCancel.Visible = false;
                        instrumentoModificadoId = 0;
                    }
                    //Llamo al metodo Guardar de la sala y le paso el objeto
                    guardar = instrumentoManager.Guardar(instrumento);
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
                    CargarData();
                    Limpiar();
                    instrumento = new Instrumento();
                    MessageBox.Show("¡Operación exitosa!");
                }
            }
        }

        void CargarData()
        {
            this.dataGInstrumento.DataSource = null;
            this.dataGInstrumento.Rows.Clear();
            var query = instrumentoManager.Listar();
            if (query != null)
            {
                foreach (var User in query)
                {
                    dataGInstrumento.Rows.Add(
                        User.Id,
                        User.Nombre,
                        User.Codigo,
                        User.Descripcion,
                        User.Precio);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnModificar.Visible = true;
            btnBorrar.Visible = true;
            btnCancel.Visible = false;
            instrumentoModificadoId = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGInstrumento.Rows.Count == 0) throw new Exception("No hay instrumentos para borrar");

                int instrumentoId = (int)this.dataGInstrumento.SelectedRows[0].Cells["IdInstrumento"].Value;
                var existeAlquiler = instrumentoManager.ExisteAlquiler(instrumentoId);
                if (existeAlquiler)
                {
                    throw new Exception("Error: El instrumento que intenta borrar esta asociado a un alquiler");
                }

                DialogResult solicitud;
                solicitud = MessageBox.Show("¿Seguro que desea eliminar el instrumento?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (solicitud == DialogResult.Yes)
                {
                    int id = (int)this.dataGInstrumento.SelectedRows[0].Cells["IdInstrumento"].Value;

                    instrumentoManager.Borrar(id.ToString());
                    CargarData();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Al terminar de modificar, presione boton guardar");
                txtNombre.Text = (string)this.dataGInstrumento.SelectedRows[0].Cells["Nombre"].Value;
                txtDescripcion.Text = (string)this.dataGInstrumento.SelectedRows[0].Cells["Descripcion"].Value;
                txtCodigo.Text = (string)this.dataGInstrumento.SelectedRows[0].Cells["Codigo"].Value;
                txtPrecio.Text = this.dataGInstrumento.SelectedRows[0].Cells["Precio"].Value.ToString();
                instrumentoModificadoId = (int)this.dataGInstrumento.SelectedRows[0].Cells["IdInstrumento"].Value;
                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
