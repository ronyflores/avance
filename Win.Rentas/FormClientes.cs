using BL.Rentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormClientes : Form
    {
        ClientesBL _clientes;
        CiudadesBL _ciudadesBL;
        public FormClientes()
        {
            InitializeComponent();
            _clientes = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientes.obtenerClientes();

            _ciudadesBL = new CiudadesBL();
            listaCiudadesBindingSource.DataSource = _ciudadesBL.ObtenerCiudades();
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            listaClientesBindingSource.EndEdit();
            var cliente = (Cliente) listaClientesBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                cliente.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                cliente.Foto = null;
            }

            var resultado = _clientes.GuardarCliente(cliente);
            if (resultado.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientes.AgregarCliente();
            listaClientesBindingSource.MoveLast();
            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            

            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Esta Seguro que Desea Eliminar Este Registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                
            }
        }

        private void Eliminar(int id)
        {

           
            var resultado = _clientes.EliminarCliente(id);


            if (resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al Eliminar el Cliente");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            _clientes.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
           
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnagregarfotoc_Click(object sender, EventArgs e)
        {
            var cliente = (Cliente)listaClientesBindingSource.Current;

            if (cliente != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;


                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);

                }

            }
            else
            {
                MessageBox.Show("Cree un Cliente antes de agregar una imagen");
            }
            
        }

        private void btnremoverfotoc_Click(object sender, EventArgs e)
        {

            fotoPictureBox.Image = null;
        }
    }
}
