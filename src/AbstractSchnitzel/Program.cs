// See https://aka.ms/new-console-template for more information

// print full path to current application
Console.WriteLine("Appcontext BaseDirectory: " 
                  + System.AppContext.BaseDirectory);

// print working directory
Console.WriteLine("Working directory: " 
    + System.IO.Directory.GetCurrentDirectory());

// print all command-line arguments
Console.WriteLine("Command line arguments:");
foreach (var arg in Environment.GetCommandLineArgs())
{
    Console.WriteLine($"  {arg}");
}

