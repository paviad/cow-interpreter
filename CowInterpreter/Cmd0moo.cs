namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd0moo : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.ProgramMemory.GoPreviousAddress();
            var count = 1;
            while (count > 0) {
                var cmd = (Cmds)cpu.ProgramMemory.GoPreviousAddress();
                if (cmd == Cmds.moo) {
                    count++;
                }
                else if (cmd == Cmds.MOO) {
                    count--;
                }
            }
            cpu.ProgramMemory.GoPreviousAddress();
        }
    }
}