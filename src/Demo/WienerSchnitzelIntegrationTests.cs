using System.Diagnostics;
using System.Text.Json;
using Xunit;

namespace Demo;

public class WienerSchnitzel
{
    public (int, string) Cook(string ingredient)
    {
        var current = Directory.GetCurrentDirectory();
        var repoDir = Path.GetFullPath(Path.Combine(current, "../../../../.."));
        var workingDir = Path.Combine(repoDir, "publish/osx-arm64");
        var appPath = Path.Combine(workingDir, "WienerSchnitzel");

        var process = new Process();
        process.StartInfo.FileName = appPath;
        process.StartInfo.Arguments = ingredient;
        process.StartInfo.WorkingDirectory = workingDir;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        process.Start();
        process.WaitForExit();

        // Read and print the output
        string output = process.StandardOutput.ReadToEnd();

        return (process.ExitCode, output);
    }
}

public class WienerSchnitzelIntegrationTests
{
    [Fact]
    public void CookWienerSchnitzel()
    {
        var app = new WienerSchnitzel();
        var (result, stdout) = app.Cook("beef");
        Assert.Equal(0, result);

        using JsonDocument json = JsonDocument.Parse(stdout);
        var baseDirectory = json.RootElement.GetProperty("baseDirectory").GetString();
        Assert.NotNull(baseDirectory);
        
        var argumentOne = json.RootElement.GetProperty("arg[1]").GetString();
        Assert.Equal("beef", argumentOne);
    }
}