﻿using BL.Rentas;
using System;
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
    public partial class FormReporteFacturas : Form
    {
        public FormReporteFacturas()
        {
            InitializeComponent();

            var _facturasBL = new FacturaBL();
            var bindingSourse = new BindingSource();
            bindingSourse.DataSource = _facturasBL.ObtenerFacturas();

            var reporte = new ReporteFacturas();
            reporte.SetDataSource(bindingSourse);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
