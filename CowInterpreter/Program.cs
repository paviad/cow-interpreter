using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CowInterpreter {
    internal class Program {
        private static void Main() {

            const string pgmHelloWorld = @"
MoO MoO MoO MoO MoO MoO MoO MoO MOO moO MoO MoO MoO MoO MoO moO MoO MoO MoO MoO moO MoO MoO MoO MoO moO MoO MoO MoO MoO MoO MoO MoO
 MoO MoO moO MoO MoO MoO MoO mOo mOo mOo mOo mOo MOo moo moO moO moO moO Moo moO MOO mOo MoO moO MOo moo mOo MOo MOo MOo Moo MoO MoO 
 MoO MoO MoO MoO MoO Moo Moo MoO MoO MoO Moo MMM mOo mOo mOo MoO MoO MoO MoO Moo moO Moo MOO moO moO MOo mOo mOo MOo moo moO moO MoO 
 MoO MoO MoO MoO MoO MoO MoO Moo MMM MMM Moo MoO MoO MoO Moo MMM MOo MOo MOo Moo MOo MOo MOo MOo MOo MOo MOo MOo Moo mOo MoO Moo 
";
            var cpu = new Cpu();

            var pgm = "";
            string line;
            do {
                line = Console.ReadLine();
                pgm += line;
            } while (!string.IsNullOrWhiteSpace(line));

            CompileProgram(pgm, cpu);

            RunProgram(cpu);
        }

        private static void RunProgram(Cpu cpu) {
            while (true) {
                var instruction = (Cmds) cpu.ProgramMemory.Value;
                var cmd = Cmd.GetCommand(instruction);
                cmd.Execute(cpu);
                try {
                    cpu.ProgramMemory.GoNextAddress();
                }
                catch {
                    break;
                }
            }
        }

        private static void CompileProgram(string pgm, Cpu cpu) {
            var cmds = Regex.Matches(pgm, "[mMoO]{3}");

            var cmds2 = (from c in cmds
                let cmd = Cmd.GetCommand(c.Value)
                where cmd.HasValue
                select cmd.Value).ToList();

            for (var i = 0; i < cmds2.Count; i++) {
                var cmd = cmds2[i];
                cpu.ProgramMemory.Value = (int) cmd;
                if (i < cmds2.Count - 1) {
                    cpu.ProgramMemory.GoNextAddress();
                }
            }

            cpu.ProgramMemory.Freeze();

            for (var i = 0; i < cmds2.Count - 1; i++) {
                cpu.ProgramMemory.GoPreviousAddress();
            }
        }
    }
}
