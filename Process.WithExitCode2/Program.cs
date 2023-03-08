using System;

namespace Process.ExternalWithExitCode2
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.ExitCode = 2;
        }
    }
}
