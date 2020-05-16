using System;
using System.IO;

namespace CowInterpreter {
    internal class Cpu {
        public Memory ProgramMemory { get; set; } = new Memory();
        public Memory DataMemory { get; set; } = new Memory();
        public int? Register { get; set; }
        public StreamReader stdin { get; set; }
        public StreamWriter stdout { get; set; }

        public Cpu() {
            stdin = new StreamReader(Console.OpenStandardInput());
            stdout = new StreamWriter(Console.OpenStandardOutput());
        }
    }
}