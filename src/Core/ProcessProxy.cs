using System.Diagnostics;

namespace Core;

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