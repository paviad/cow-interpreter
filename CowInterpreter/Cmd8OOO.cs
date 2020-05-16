namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd8OOO : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.DataMemory.Value = 0;
        }
    }
}