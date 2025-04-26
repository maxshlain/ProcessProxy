
var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
var msg = $"Base directory: {baseDirectory}";
Console.WriteLine(msg);

var executingAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
var workingDirectory = System.IO.Path.GetDirectoryName(executingAssemblyLocation); 
msg = $"Working directory: {workingDirectory}";
Console.WriteLine(msg);

// print all command-line arguments
Console.WriteLine("Command line arguments:");
foreach (var arg in Environment.GetCommandLineArgs())
{
    Console.WriteLine($"  {arg}");
}

