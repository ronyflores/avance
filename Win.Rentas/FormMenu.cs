﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Rentas
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProductos = new FormProductos();
            formProductos.MdiParent = this;
            formProductos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
        }

        private void rentarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRentas = new FormRentas();
            formRentas.MdiParent = this;
            formRentas.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProveedores = new FormProveedores();
            formProveedores.MdiParent = this;
            formProveedores.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporteProductos = new FormReporteProductos();
            FormReporteProductos.MdiParent = this;
            FormReporteProductos.Show();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormReporteFacturas = new FormReporteFacturas();
            FormReporteFacturas.MdiParent = this;
            FormReporteFacturas.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCompra = new FormCompra();
            formCompra.MdiParent = this;
            formCompra.Show();
        }
    }
}
