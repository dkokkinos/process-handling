using McMaster.Extensions.CommandLineUtils;
using System;
using System.Diagnostics;

namespace Process.ExternalWithJsonResult
{
    class Program
    {
        [Option(ShortName = "x", Description = "the first number to add.")]
        public int X { get; set; }

        [Option(ShortName = "y", Description = "the second number to add.")]
        public int Y { get; set; }

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            Console.Write(X + Y);
        }
    }
}
