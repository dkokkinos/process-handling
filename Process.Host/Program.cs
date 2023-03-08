using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using _Process = System.Diagnostics.Process;

namespace Process.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var processWithStringResult = new ProcessController(@"..\..\..\..\Process.StringResult\bin\Debug\netcoreapp3.1\Process.StringResult.exe");
            var res = processWithStringResult.RunAndGetResult();
            Console.WriteLine("Result from Process.StringResult:");
            Console.WriteLine(JsonConvert.SerializeObject(res));

            var processWithExitCode2 = new ProcessController(@"..\..\..\..\Process.WithExitCode2\bin\Debug\netcoreapp3.1\Process.WithExitCode2.exe");
            res = processWithExitCode2.RunAndGetResult();
            Console.WriteLine("Result from Process.WithExitCode2:");
            Console.WriteLine(JsonConvert.SerializeObject(res));

            var processWithArgs = new ProcessController(@"..\..\..\..\Process.WithArgs\bin\Debug\netcoreapp3.1\Process.WithArgs.exe",
                new Dictionary<string, string>()
                {
                    {"x", "1"}, {"y", "2"}
                });
            res = processWithArgs.RunAndGetResult();
            Console.WriteLine("Result from Process.WithArgs:");
            Console.WriteLine(JsonConvert.SerializeObject(res));

            var processWithJsonResult = new ProcessController(@"..\..\..\..\Process.WithJsonResult\bin\Debug\netcoreapp3.1\Process.WithJsonResult.exe");
            var res2 = processWithJsonResult.RunAndGetResult<User>();
            Console.WriteLine("Result from Process.WithJsonResult:");
            Console.WriteLine(JsonConvert.SerializeObject(res2));
        }
    }

    class User
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
