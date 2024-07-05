using Laifu.Win32.Proc;

//Console.WriteLine(WindowStyle.Caption);

var proc = WindowProc.CurrentWindows.FirstOrDefault(proc => proc.Caption.Contains("Visual"));
Console.WriteLine(proc.Caption);

Console.WriteLine(WindowStyle.SysMenu);