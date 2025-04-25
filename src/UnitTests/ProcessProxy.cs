using System.Diagnostics;

namespace UnitTests;

public interface IAbstractProcess
{
    ProcessStartInfo StartInfo { get; }
    StreamReader StandardOutput { get; }
    int ExitCode { get; }
    bool Start();
    void WaitForExit();
}

public class AbstractProcess : IAbstractProcess
{
    public AbstractProcess()
    {
        _process = new Process();
    }

    private readonly Process _process;
    public ProcessStartInfo StartInfo => _process.StartInfo;
    public StreamReader StandardOutput => _process.StandardOutput;
    public int ExitCode => _process.ExitCode;
    public bool Start() => _process.Start();

    public void WaitForExit()
    {
        _process.WaitForExit();
    }
}

public interface IProcessProxy
{
    IAbstractProcess NewProcess();
}

public class ProcessProxy : IProcessProxy
{
    public IAbstractProcess NewProcess()
    {
        return new AbstractProcess();
    }

    public void StartProcess(string name, string arguments)
    {
        Process.Start(name, arguments);
    }
}