using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CowInterpreter {
    internal class Cpu {
        public Memory ProgramMemory { get; set; } = new Memory();
        public Memory DataMemory { get; set; } = new Memory();
        public int? Register { get; set; }
        public StreamReader stdin { get; set; }
        public StreamWriter stdout { get; set; }
        public int ProgramAddress { get; set; }

        public Cpu() {
            stdin = new StreamReader(Console.OpenStandardInput());
            stdout = new StreamWriter(Console.OpenStandardOutput());
        }

        public void CompileProgram(string pgm) {
            var cmds = Regex.Matches(pgm, "[mMoO]{3}");

            var cmds2 = (from c in cmds
                let cmd = Cmd.GetCommand(c.Value)
                where cmd.HasValue
                select cmd.Value).ToList();

            for (var i = 0; i < cmds2.Count; i++) {
                var cmd = cmds2[i];
                ProgramMemory.Value = (int)cmd;
                if (i < cmds2.Count - 1) {
                    ProgramMemory.GoNextAddress();
                }
            }

            ProgramMemory.Freeze();

            for (var i = 0; i < cmds2.Count - 1; i++) {
                ProgramMemory.GoPreviousAddress();
            }
        }

        public void RunProgram() {
            while (true) {
                var instruction = (Cmds)ProgramMemory.Value;
                var cmd = Cmd.GetCommand(instruction);
                ProgramAddress = ProgramMemory.Address;
                cmd.Execute(this);
                try {
                    ProgramMemory.GoNextAddress();
                }
                catch {
                    break;
                }
            }
        }

        public void Print() {
            Console.WriteLine("Program Memory:");
            ProgramMemory.Print(true);
            Console.WriteLine("Data Memory:");
            DataMemory.Print();
        }
    }
}