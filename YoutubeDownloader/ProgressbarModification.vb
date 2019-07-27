Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Module ProgressbarModification
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal w As IntPtr, ByVal l As IntPtr) As IntPtr
    End Function
    <Extension()>
    Public Sub SetState(ByVal pBar As ProgressBar, ByVal state As Integer)
        SendMessage(pBar.Handle, 1040, CType(state, IntPtr), IntPtr.Zero)
    End Sub
End Module
