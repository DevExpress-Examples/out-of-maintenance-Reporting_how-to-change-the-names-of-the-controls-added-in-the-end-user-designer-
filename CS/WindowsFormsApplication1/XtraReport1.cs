using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication1
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
            
        }

        private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //nWindDataSet1.WriteXml("test.xml", System.Data.XmlWriteMode.WriteSchema);
            
           
        }

        private void XtraReport1_AfterPrint(object sender, EventArgs e)
        {
          
        }

        private void xrTableRow3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel1_SummaryRowChanged(object sender, EventArgs e) {

        }

        private void xrLabel1_SummaryCalculated(object sender, TextFormatEventArgs e) {

        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {

        }

        private void xrLabel1_SummaryReset(object sender, EventArgs e) {
        }

        private void xrPivotGrid1_CustomCellValue(object sender, DevExpress.XtraPivotGrid.PivotCellValueEventArgs e) {
        
        }

    }
}
