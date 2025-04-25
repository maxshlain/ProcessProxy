using System.Diagnostics;

namespace Core;

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