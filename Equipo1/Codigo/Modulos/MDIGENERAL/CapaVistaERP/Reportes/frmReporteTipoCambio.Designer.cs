﻿
namespace CapaVistaERP.Reportes
{
    partial class frmReporteTipoCambio
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
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.Size = new System.Drawing.Size(931, 581);
            this.crystalReportViewer3.TabIndex = 0;
            // 
            // frmReporteTipoCambio
            // 
            this.ClientSize = new System.Drawing.Size(931, 581);
            this.Controls.Add(this.crystalReportViewer3);
            this.Name = "frmReporteTipoCambio";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Reportetipocambio Reportetipocambio1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private ReporteTIpoCambioAPi ReporteTIpoCambioAPi1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
    }
}