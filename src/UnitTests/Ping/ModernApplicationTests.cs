using System.Diagnostics;
using System.Text;
using Core;
using Moq;

namespace UnitTests.Ping;

public class ModernApplication
{
    private readonly IProcessProxy _processProxy;

    public ModernApplication(IProcessProxy processProxy)
        => _processProxy = processProxy;

    public int PingServer(string host)
    {
        IAbstractProcess process = _processProxy.NewProcess();
        process.StartInfo.FileName = "ping";
        process.StartInfo.Arguments = $"-c 1 {host}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        process.Start();

        // Read and print the output
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        process.WaitForExit();

        return process.ExitCode;
    }
}

public class ModernApplicationTests
{
    [Fact]
    public void Ping_127_0_0_1_WithRealProcess()
    {
        var proxy = new ProcessProxy();
        var app = new ModernApplication(proxy);
        var result = app.PingServer("127.0.0.1");
        Assert.Equal(0, result);
    }

    [Fact]
    public void Ping_127_0_0_1_WithMockedProcess()
    {
        // ARRANGE
        ProcessStartInfo processStartInfoFromTest = new ProcessStartInfo();

        var mockedProcess = Mock.Of<IAbstractProcess>();
        Mock.Get(mockedProcess)
            .SetupGet(a => a.StartInfo)
            .Returns(processStartInfoFromTest);

        string stdOutFromTest = "ahahaha";
        byte[] byteArray = Encoding.ASCII.GetBytes(stdOutFromTest);
        MemoryStream stream = new MemoryStream(byteArray);

        Mock.Get(mockedProcess)
            .SetupGet(b => b.StandardOutput)
            .Returns(new StreamReader(stream));

        var mockedProcessProxy = Mock.Of<IProcessProxy>();
        Mock.Get(mockedProcessProxy)
            .Setup(a => a.NewProcess())
            .Returns(mockedProcess);

        var app = new ModernApplication(mockedProcessProxy);

        // ACT
        var result = app.PingServer("127.0.0.1");

        // ASSERT
        Assert.Equal(0, result);
        Assert.Equal("ping", processStartInfoFromTest.FileName);
        Assert.Equal("-c 1 127.0.0.1", processStartInfoFromTest.Arguments);
    }
}