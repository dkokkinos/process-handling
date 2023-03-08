using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using _Process = System.Diagnostics.Process;

namespace Process.Host
{
    public class ProcessController
    {
        private readonly Dictionary<string, string> _args;
        private readonly string _fileName;

        public ProcessController(string fileName, Dictionary<string, string> args = null)
        {
            _fileName = fileName;
            _args = args ?? new Dictionary<string, string>();
        }

        public ProcessResult<string> RunAndGetResult()
            => RunAndGetResult<string>();

        public ProcessResult<T> RunAndGetResult<T>() 
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = _fileName,
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
            };

            if (_args.Any())
                startInfo.Arguments = string.Join(" ", _args.Select(x => $"-{x.Key} {x.Value}"));

            var process = _Process.Start(startInfo);
            process.WaitForExit();
            var output = process.StandardOutput.ReadToEnd();

            var exitCode = process.ExitCode;

            T result = default;
            if (exitCode == 0 )
            {
                if (typeof(T) != typeof(string) && !typeof(T).IsPrimitive)
                {
                    result = JsonConvert.DeserializeObject<T>(output);
                }
                else
                    result = (T)(object)output;
            }
            return new ProcessResult<T>(result, exitCode);
        }
    }

    public class ProcessResult<T>
    {
        public T Result { get; }
        public int ExitCode { get; }
        public bool HasError => ExitCode != 0;

        public ProcessResult(T result, int exitCode)
        {
            Result = result;
            ExitCode = exitCode;
        }
    }
}
