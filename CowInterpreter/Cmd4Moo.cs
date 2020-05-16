using System.Text;

namespace CowInterpreter {
    internal class Cmd4Moo : Cmd {
        public override void Execute(Cpu cpu) {
            if (cpu.DataMemory.Value == 0) {
                cpu.DataMemory.Value = cpu.stdin.Read();
            }
            else {
                var ch = Encoding.ASCII.GetString(new[] { (byte)cpu.DataMemory.Value });
                cpu.stdout.Write(ch);
                cpu.stdout.Flush();
            }
        }
    }
}