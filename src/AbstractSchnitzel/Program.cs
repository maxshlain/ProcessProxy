
Console.WriteLine("{");
var tab = "  ";

var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
var msg = $"{tab}\"baseDirectory\": \"{baseDirectory}\",";
Console.WriteLine(msg);

var executingAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
var workingDirectory = System.IO.Path.GetDirectoryName(executingAssemblyLocation); 
msg = $"{tab}\"workingDirectory\": \"{workingDirectory}\",";
Console.WriteLine(msg);

var allArgs = Environment.GetCommandLineArgs();
for (int i=0; i < allArgs.Length; i++)
{
    var arg = Environment.GetCommandLineArgs()[i];
    msg = $"{tab}\"arg[{i}]\": \"{arg}\",";
    Console.WriteLine(msg);
}

msg = $"{tab}\"dummyLastKey\": \"dummyLastValue\"";
Console.WriteLine(msg);

Console.WriteLine("}");