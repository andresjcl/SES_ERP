'UPGRADE_WARNING: El proyecto entero se debe compilar una vez antes de poder mostrar una matriz de controles ActiveX

Imports System.ComponentModel

<ProvideProperty("Index",GetType(AxMSDataListLib.AxDataCombo))> Public Class AxDataComboArray
	Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray
	Implements IExtenderProvider

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Container As IContainer)
		MyBase.New(Container)
	End Sub

	Public Shadows Event [ClickEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_ClickEvent)
	Public Shadows Event [DblClick] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_DblClickEvent)
	Public Shadows Event [KeyDownEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyDownEvent)
	Public Shadows Event [KeyPressEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyPressEvent)
	Public Shadows Event [KeyUpEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyUpEvent)
	Public Shadows Event [MouseDownEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseDownEvent)
	Public Shadows Event [MouseMoveEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseMoveEvent)
	Public Shadows Event [MouseUpEvent] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseUpEvent)
	Public Shadows Event [Change] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [OLEStartDrag] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEStartDragEvent)
	Public Shadows Event [OLEGiveFeedback] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEGiveFeedbackEvent)
	Public Shadows Event [OLESetData] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLESetDataEvent)
	Public Shadows Event [OLECompleteDrag] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLECompleteDragEvent)
	Public Shadows Event [OLEDragOver] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEDragOverEvent)
	Public Shadows Event [OLEDragDrop] (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEDragDropEvent)

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
		If TypeOf target Is AxMSDataListLib.AxDataCombo Then
			Return BaseCanExtend(target)
		End If
	End Function

	Public Function GetIndex(ByVal o As AxMSDataListLib.AxDataCombo) As Short
		Return BaseGetIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxMSDataListLib.AxDataCombo, ByVal Index As Short)
		BaseSetIndex(o, Index)
	End Sub

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxMSDataListLib.AxDataCombo) As Boolean
		Return BaseShouldSerializeIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxMSDataListLib.AxDataCombo)
		BaseResetIndex(o)
	End Sub

	Default Public ReadOnly Property Item(ByVal Index As Short) As AxMSDataListLib.AxDataCombo
		Get
			Item = CType(BaseGetItem(Index), AxMSDataListLib.AxDataCombo)
		End Get
	End Property

	Protected Overrides Function GetControlInstanceType() As System.Type
		Return GetType(AxMSDataListLib.AxDataCombo)
	End Function

	Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
		Dim ctl As AxMSDataListLib.AxDataCombo = CType(o, AxMSDataListLib.AxDataCombo)
		MyBase.HookUpControlEvents(o)
		If Not ClickEventEvent Is Nothing Then
			AddHandler ctl.ClickEvent, New AxMSDataListLib.DDataComboEvents_ClickEventHandler(AddressOf HandleClickEvent)
		End If
		If Not DblClickEvent Is Nothing Then
			AddHandler ctl.DblClick, New AxMSDataListLib.DDataComboEvents_DblClickEventHandler(AddressOf HandleDblClick)
		End If
		If Not KeyDownEventEvent Is Nothing Then
			AddHandler ctl.KeyDownEvent, New AxMSDataListLib.DDataComboEvents_KeyDownEventHandler(AddressOf HandleKeyDownEvent)
		End If
		If Not KeyPressEventEvent Is Nothing Then
			AddHandler ctl.KeyPressEvent, New AxMSDataListLib.DDataComboEvents_KeyPressEventHandler(AddressOf HandleKeyPressEvent)
		End If
		If Not KeyUpEventEvent Is Nothing Then
			AddHandler ctl.KeyUpEvent, New AxMSDataListLib.DDataComboEvents_KeyUpEventHandler(AddressOf HandleKeyUpEvent)
		End If
		If Not MouseDownEventEvent Is Nothing Then
			AddHandler ctl.MouseDownEvent, New AxMSDataListLib.DDataComboEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
		End If
		If Not MouseMoveEventEvent Is Nothing Then
			AddHandler ctl.MouseMoveEvent, New AxMSDataListLib.DDataComboEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
		End If
		If Not MouseUpEventEvent Is Nothing Then
			AddHandler ctl.MouseUpEvent, New AxMSDataListLib.DDataComboEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
		End If
		If Not ChangeEvent Is Nothing Then
			AddHandler ctl.Change, New System.EventHandler(AddressOf HandleChange)
		End If
		If Not OLEStartDragEvent Is Nothing Then
			AddHandler ctl.OLEStartDrag, New AxMSDataListLib.DDataComboEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
		End If
		If Not OLEGiveFeedbackEvent Is Nothing Then
			AddHandler ctl.OLEGiveFeedback, New AxMSDataListLib.DDataComboEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
		End If
		If Not OLESetDataEvent Is Nothing Then
			AddHandler ctl.OLESetData, New AxMSDataListLib.DDataComboEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
		End If
		If Not OLECompleteDragEvent Is Nothing Then
			AddHandler ctl.OLECompleteDrag, New AxMSDataListLib.DDataComboEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
		End If
		If Not OLEDragOverEvent Is Nothing Then
			AddHandler ctl.OLEDragOver, New AxMSDataListLib.DDataComboEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
		End If
		If Not OLEDragDropEvent Is Nothing Then
			AddHandler ctl.OLEDragDrop, New AxMSDataListLib.DDataComboEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
		End If
	End Sub

	Private Sub HandleClickEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_ClickEvent) 
		RaiseEvent [ClickEvent] (sender, e)
	End Sub

	Private Sub HandleDblClick (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_DblClickEvent) 
		RaiseEvent [DblClick] (sender, e)
	End Sub

	Private Sub HandleKeyDownEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyDownEvent) 
		RaiseEvent [KeyDownEvent] (sender, e)
	End Sub

	Private Sub HandleKeyPressEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyPressEvent) 
		RaiseEvent [KeyPressEvent] (sender, e)
	End Sub

	Private Sub HandleKeyUpEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_KeyUpEvent) 
		RaiseEvent [KeyUpEvent] (sender, e)
	End Sub

	Private Sub HandleMouseDownEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseDownEvent) 
		RaiseEvent [MouseDownEvent] (sender, e)
	End Sub

	Private Sub HandleMouseMoveEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseMoveEvent) 
		RaiseEvent [MouseMoveEvent] (sender, e)
	End Sub

	Private Sub HandleMouseUpEvent (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_MouseUpEvent) 
		RaiseEvent [MouseUpEvent] (sender, e)
	End Sub

	Private Sub HandleChange (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [Change] (sender, e)
	End Sub

	Private Sub HandleOLEStartDrag (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEStartDragEvent) 
		RaiseEvent [OLEStartDrag] (sender, e)
	End Sub

	Private Sub HandleOLEGiveFeedback (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEGiveFeedbackEvent) 
		RaiseEvent [OLEGiveFeedback] (sender, e)
	End Sub

	Private Sub HandleOLESetData (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLESetDataEvent) 
		RaiseEvent [OLESetData] (sender, e)
	End Sub

	Private Sub HandleOLECompleteDrag (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLECompleteDragEvent) 
		RaiseEvent [OLECompleteDrag] (sender, e)
	End Sub

	Private Sub HandleOLEDragOver (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEDragOverEvent) 
		RaiseEvent [OLEDragOver] (sender, e)
	End Sub

	Private Sub HandleOLEDragDrop (ByVal sender As System.Object, ByVal e As AxMSDataListLib.DDataComboEvents_OLEDragDropEvent) 
		RaiseEvent [OLEDragDrop] (sender, e)
	End Sub

End Class

