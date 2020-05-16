namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd7MOO : Cmd {
        public override void Execute(Cpu cpu) {
            if (cpu.DataMemory.Value != 0) {
                return;
            }

            cpu.ProgramMemory.GoNextAddress();
            var count = 1;
            while (count > 0) {
                var v = cpu.ProgramMemory.GoNextAddress();
                if (v == (int)Cmds.MOO) {
                    count++;
                }
                else if (v == (int)Cmds.moo) {
                    count--;
                }
            }
        }
    }
}