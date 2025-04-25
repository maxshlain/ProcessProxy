using System.Diagnostics;

namespace Core;

public interface IAbstractProcess
{
    ProcessStartInfo StartInfo { get; }
    StreamReader StandardOutput { get; }
    int ExitCode { get; }
    bool Start();
    void WaitForExit();
}