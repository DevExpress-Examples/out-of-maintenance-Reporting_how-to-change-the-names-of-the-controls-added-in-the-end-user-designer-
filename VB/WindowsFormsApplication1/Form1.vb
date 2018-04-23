Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraBars
Imports System.IO
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Native
Imports System.ComponentModel.Design.Serialization
Imports System.ComponentModel.Design
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UserDesigner

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim report As New XtraReport1()
			AddHandler report.DesignerLoaded, AddressOf OnDesignerLoaded
			report.ShowDesignerDialog()
		End Sub
		Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)

			Dim nc As INameCreationService = TryCast(e.DesignerHost.GetService(GetType(INameCreationService)), INameCreationService)

			Dim myNC As New MyNameCreationService(nc)

			e.DesignerHost.RemoveService(GetType(INameCreationService))

			e.DesignerHost.AddService(GetType(INameCreationService), myNC)

		End Sub
		Private Sub report_DesignerLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs)
			Dim serv As IComponentChangeService = TryCast(e.DesignerHost.GetService(GetType(IComponentChangeService)), IComponentChangeService)
			AddHandler serv.ComponentAdded, AddressOf serv_ComponentAdded
		End Sub

		Private Sub serv_ComponentAdded(ByVal sender As Object, ByVal e As ComponentEventArgs)
			Dim cont As XRControl = TryCast(e.Component, XRControl)
			If cont IsNot Nothing Then
				If cont.DataBindings("Text") IsNot Nothing Then
					Dim pdc As PropertyDescriptorCollection = TypeDescriptor.GetProperties(cont)

					Dim s As String = cont.DataBindings("Text").DataMember.Substring(cont.DataBindings("Text").DataMember.LastIndexOf(".") + 1) & "_test"
					Dim ss As String = s
					Dim host As IDesignerHost = TryCast(cont.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
					Dim counter As Integer = 1
					Do While host.Container.Components(ss) IsNot Nothing
						ss = s & counter
						counter += 1
					Loop
					cont.Site.Name = ss
					pdc("Name").SetValue(cont, ss)
				End If
			End If
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			Dim report As New XtraReport1()
			AddHandler report.DesignerLoaded, AddressOf report_DesignerLoaded
			report.ShowDesignerDialog()
		End Sub

	End Class
	Public Class MyNameCreationService
		Implements INameCreationService

		Private nc As INameCreationService
		Private counter As Integer = 0


		Public Sub New(ByVal nc As INameCreationService)

			Me.nc = nc
		End Sub

		Public Function CreateName(ByVal container As IContainer, ByVal dataType As Type) As String Implements INameCreationService.CreateName

			counter += 1
			Return "MyCustomName" & counter.ToString()

		End Function

		Public Function IsValidName(ByVal name As String) As Boolean Implements INameCreationService.IsValidName

			Return nc.IsValidName(name)

		End Function

		Public Sub ValidateName(ByVal name As String) Implements INameCreationService.ValidateName

			nc.ValidateName(name)

		End Sub

	End Class



End Namespace
