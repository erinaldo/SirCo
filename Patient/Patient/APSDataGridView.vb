
' APSDataGridView.vb
'
' Wrapper for DataGridView
' Modifies default behavior so that Combo Boxes are editable (type-in) by default.
'
' This can be handy because type-in DataGridView combo boxes are a lot more
' involved than you might think.
'
' Aaron Stewart, 2007
' Instructions:
' (1) Create a new Windows Forms project in VB.NET 2005 or higher.
' 
' (2) Create a new class (not a user control) named APSDataGridView.vb
' and paste this code into it, replacing what is there.
'
' (3) Go to Project -> ...Properties -> Application tab -> Root Namespace,
' and clear the root namespace. (This is necessary for VB, not C#)
'
' (4) Compile the project. The APSDataGridView is now available in the Toolbox, at the top.
'
' (5) Now go to your form (such as Form1.vb) and add an APSDataGridView control using the designer.
' Don't make it too small.
'
' (6) Now in your form code you can paste the example or write your own code.
'
' (7) Compile and run
' 
' (8) You can try it with the test cases below.

' Some differences when using APSDataGridView:
'
' (1) If you want to set Combo Box parameters with the EditingControlShowing event,
' use the EditingControlShowing2 event instead. If you are not dealing with Combo Boxes,
' you can use the regular EditingControlShowing event.
'
' (2) Do not use the CellValidating event. Use CellValidating2 instead.
' (This allows combo box validation handler to work without conflicts.)


' The DataGridView does not directly support type-in (editable) ComboBox mode,
' and all of the published examples I have seen are incomplete.
'
' To get the DataGridView to work properly with ComboBoxes, do ALL of the following:
' (1) In DataGridView.EditingControlShowing, set ComboBox.DropDownStyle = ComboBoxStyle.DropDown for the desired column(s) (Source: DataGridView FAQ)
' (2) Set DataGridView.NotifyCurrentCellDirty(True) in DataGridView.EditingControlShowing (Source: Microsoft Support)
' (3) In DataGridView1.CellValidating, force the ComboBox SelectedIndex : cbo.SelectedIndex = cbo.FindStringExact(cbo.Text.Trim) (Source: Forum member Aspnot, http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=254131&SiteID=1 ; See also http://msdn.microsoft.com/msdnmag/issues/06/01/DevQA/ )
' (4) In ComboBox.PreviewKeyDown, if e.KeyCode = Keys.Enter then force ComboBox.DroppedDown = False (Source: My own experiments)
' (5) In ComboBox.PreviewKeyDown, if e.KeyCode = Keys.Escape then set ComboBox.Text = "" . (Source: My own experiments)
' Even with all of these, the behavior isn't as nice as with Access or Excel.
' Motivation for these:
' #1 - This puts the combo box into type-in mode
' #2 - Without this the DataGridView stays in an unfinished edit mode even after you leave the cell
' (Also, test case #2 below will fail if this is done in ComboBox.TextChanged instead of 
' DataGridView.EditingControlShowing and the ComboBox is set to AutoCompleteMode.SuggestAppend)
' #3 - Similar to #2 - the DataGridView won't work right without it
' #4 - Resolves an issue with ComboBoxes where if you open the drop-down and type an entry and press ENTER, it loses the value.
' #5 - For test case #11. Allows ESC to work properly with the DataGridView. Normally ESC works fine, but if AutoComplete (Append) is enabled AND you enter text that matches something on the list, then something interferes with the ESC key.
' Test cases for validating an editable ComboBox :
' Try all of these cases on the new row at the bottom of the DataGridView (and if you like, also try them on an interior row).
' 
' Here are the test cases:
' (1) Drop-down, click an item, submit
' (2) Type a known value, submit (try this with and without matching capitalization)
' (3) Drop-down, type a known value (do not use the arrow keys to select it), press ENTER
' (4) Drop-down, select a value using the arrow keys or mouse, press ENTER
' (5)* Drop-down, start typing a known value, then try to use the arrow keys to select a different value (this case does not work cleanly like in Access or Excel)
' (6) Enter a value other than the first value, submit, return to this cell, Clear it, press ENTER.
' (7)* Set AutoCompleteMode.SuggestAppend, AutoCompleteSource.ListItems. It works but it isn't as nice as Access or Excel.
' (8)* At the new row, drop-down but don't enter a value, submit. (This is probably acceptable behavior).
' (9) Start entering a known value. Then drop-down. Then TAB. (http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=254131&SiteID=1)
' (10) Start typing a value not matching the list, then press ESC to cancel it. The new row should completely disappear.
' (11) Start typing a value that matches an item in the list (so that AutoComplete kicks in), then press ESC to cancel it. The new row should completely disappear. It might be tolerable if it leaves a blank but no pencil icon.
'
' Cases marked with an asterisk(*) do not work as nicely as Access or Excel.
' Notes: 
' (i) All of these cases start with an empty combo box, unless otherwise specified.
' (ii) Drop-down : by clicking on the mouse or pressing Alt+Down
' (iii) Submit : Normally clicking off the control, pressing TAB, and
' pressing ENTER are all ways submit the value. However, in some
' cases a specific submit method is specified.
' (iv) Clear: Press Ctrl+0 or edit and delete the text or edit and press delete.
' 

Imports System.Windows.Forms
Namespace APS.Windows.Forms
    ' Derived DataGridView that takes care of the details so combo boxes use type-in (editable) mode.
    Public Class APSDataGridView
        Inherits System.Windows.Forms.DataGridView
        ' It seems to generate the delegate [event]EventHandler automatically from the event declaration...
        'Public Delegate Sub ComboBoxItemNotInListEventHandler(ByVal dgv As DataGridView, ByVal cbo As ComboBox, ByVal cboColumn As DataGridViewComboBoxColumn, ByVal e As DataGridViewCellValidatingEventArgs)
        Public Event ComboBoxItemNotInList(ByVal dgv As DataGridView, ByVal cbo As ComboBox, ByVal cboColumn As DataGridViewComboBoxColumn, ByVal e As DataGridViewCellValidatingEventArgs)
        ' Constructor
        Public Sub New()
            MyBase.New()
        End Sub

        ' This makes combo boxes "editable" so you can type in them. See the DataGridView FAQ.
        Protected Overrides Sub OnEditingControlShowing( _
        ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
            Dim dgv As DataGridView = Me 'sender
            If (TypeOf e.Control Is ComboBox) Then
                Dim cbo As ComboBox = DirectCast(e.Control, ComboBox)
                ' Optional: http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=254131&SiteID=1
                'cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                'cbo.AutoCompleteSource = AutoCompleteSource.ListItems
                ' This makes it a type-in combo box
                cbo.DropDownStyle = ComboBoxStyle.DropDown
                ' Adjust the ComboBox behavior:
                AddHandler cbo.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf comboBox_PreviewKeyDown)
                ' (Thanks to Ying Liu, Microsoft Support
                dgv.NotifyCurrentCellDirty(True)
            End If
            ' Call registered event handlers...
            MyBase.OnEditingControlShowing(e)
        End Sub

        ' Validate typed-in values...
        Protected Overrides Sub OnCellValidating(ByVal e As DataGridViewCellValidatingEventArgs)
            Dim dgv As DataGridView = Me 'sender
            If Not TypeOf (dgv.EditingControl) Is ComboBox Then
                ' Every control path should call MyBase.OnCellValidating
                MyBase.OnCellValidating(e)
            Else
                Dim cbo As ComboBox = dgv.EditingControl
                If (cbo Is Nothing) Then
                    MyBase.OnCellValidating(e)
                    Exit Sub ' cbo is Nothing if the user did not edit the cell
                End If
                ' This does two things:
                ' (1) This makes the combo box case-insensitive.
                ' (2) You have to force the SelectedIndex when using type-in mode or it will not properly recognize the change
                ' This little gem comes from 
                ' http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=254131&SiteID=1
                cbo.SelectedIndex = cbo.FindStringExact(cbo.Text.Trim)
                ' You could customize the handling below on a column-by-column basis...
                If cbo.SelectedIndex = -1 Then ' The item wasn't in the list...
                    ' Is it because the value is empty?
                    If (cbo.Text.Trim = String.Empty) Then
                        ' We assume that it's okay to have an empty value here...
                        ' Let the user delete the value...
                        ' Don't Raise Event ComboBoxItemNotInList...
                    Else
                        ' A value was entered but it was not in the list...
                        Dim cboColumn As DataGridViewComboBoxColumn = dgv.Columns(e.ColumnIndex)
                        RaiseEvent ComboBoxItemNotInList(dgv, cbo, cboColumn, e)
                        If (e.Cancel = True) Then
                            ' How do we cancel a value if it creates a new row?
                            Beep() ' Set a breakpoint here
                            ' ? force dgv value to empty???
                            ' Don't return yet - we still need to call the base class event handler
                        Else
                            ' If the user added the item to the combo box, we need to accept the new value...
                            ' Again, from http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=254131&SiteID=1
                            cbo.SelectedIndex = cbo.FindStringExact(cbo.Text.Trim)
                        End If
                    End If
                End If
            End If
            ' Call the base class handler and user handlers...
            MyBase.OnCellValidating(e)
        End Sub
        Protected Shared Sub comboBox_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
            ' There is a glitch if you are using a ComboBox either in a DataGridView or standalone.
            ' If you open the ComboBox dropdown but then type a value and press ENTER, the value is lost.
            ' This error does not appear if you press TAB.
            ' This is the workaround.
            If (e.KeyCode = Keys.Enter) Then
                Dim cbo As ComboBox = sender
                If cbo.DroppedDown Then
                    cbo.DroppedDown = False
                End If
            End If
            ' Allow the ESC key to cancel changes even if AutoComplete mode has been active.
            If (e.KeyCode = Keys.Escape) Then
                Dim cbo As ComboBox = sender
                ' I don't know why this works, but it does:
                cbo.Text = ""
            End If
        End Sub
    End Class
End Namespace