using Laifu.Win32.Proc;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("test with app");

try
{
    var proc = WindowProc.CurrentWindows.First(p => p.ClassName.ToLower().Contains("VoipWnd".ToLower()));

    //Console.WriteLine(proc.Caption);
    //Console.WriteLine(proc.ClassName);

    //Console.WriteLine(string.Join(' ', proc.Styles));
    //Console.WriteLine(string.Join(' ', proc.ExtendedStyles));

    //proc.AddExtendStyle(WindowStyleEx.Layered);
    //proc.RemoveExtendStyle(WindowStyleEx.Transparent);
    //proc.RemoveExtendStyle(WindowStyleEx.NoActivate);

    //Console.WriteLine(string.Join(' ', proc.Styles));
    //Console.WriteLine(string.Join(' ', proc.ExtendedStyles));

    proc.RemoveExtendStyle(WindowStyleEx.Transparent);

    proc.Opacity = 1;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}