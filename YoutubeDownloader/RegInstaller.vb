Imports System.Security.Principal
Module RegInstaller
    Public Function IsRunningAsAdmin() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function
    Public Sub InstallFileExtension()
        Console.WriteLine("Installing extension...")
        My.Computer.Registry.ClassesRoot.CreateSubKey(".ytdl").SetValue("", "YouTube Downloader Save File", Microsoft.Win32.RegistryValueKind.String)
        My.Computer.Registry.ClassesRoot.CreateSubKey("YouTube Downloader Save File\shell\open\command").SetValue("", Application.ExecutablePath & " ""%l"" ", Microsoft.Win32.RegistryValueKind.String)
        Console.WriteLine("done.")
    End Sub
End Module
