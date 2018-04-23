using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars;
using System.IO;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Native;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel.Design;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UserDesigner;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            report.DesignerLoaded += new DevExpress.XtraReports.UserDesigner.DesignerLoadedEventHandler(OnDesignerLoaded);
            report.ShowDesignerDialog();
        }
        void OnDesignerLoaded(object sender, DesignerLoadedEventArgs e) {

            INameCreationService nc = e.DesignerHost.GetService(typeof(INameCreationService)) as INameCreationService;

            MyNameCreationService myNC = new MyNameCreationService(nc);

            e.DesignerHost.RemoveService(typeof(INameCreationService));

            e.DesignerHost.AddService(typeof(INameCreationService), myNC);

        }
        void report_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e) {
            IComponentChangeService serv = e.DesignerHost.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            serv.ComponentAdded += new ComponentEventHandler(serv_ComponentAdded);
        }

        void serv_ComponentAdded(object sender, ComponentEventArgs e) {
            XRControl cont  = e.Component as XRControl;
            if(cont != null) {
                if(cont.DataBindings["Text"] != null) {
                    PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(cont);

                    string s = cont.DataBindings["Text"].DataMember.Substring(cont.DataBindings["Text"].DataMember.LastIndexOf(".") + 1) + "_test";
                    string ss = s;
                    IDesignerHost host = cont.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    int counter = 1;
                    while(host.Container.Components[ss] != null) {
                        ss = s + counter;
                        counter++;
                    }
                    cont.Site.Name = ss;
                    pdc["Name"].SetValue(cont, ss);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            report.DesignerLoaded += new DevExpress.XtraReports.UserDesigner.DesignerLoadedEventHandler(report_DesignerLoaded);
            report.ShowDesignerDialog();
        }

    }
    public class MyNameCreationService : INameCreationService {

        INameCreationService nc;
        int counter = 0;


        public MyNameCreationService(INameCreationService nc) {

            this.nc = nc;
        }

        public string CreateName(IContainer container, Type dataType) {

            counter++;
            return "MyCustomName" + counter.ToString();

        }

        public bool IsValidName(string name) {

            return nc.IsValidName(name);

        }

        public void ValidateName(string name) {

            nc.ValidateName(name);

        }

    }


  
}
