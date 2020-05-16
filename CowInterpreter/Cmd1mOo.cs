namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd1mOo : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.DataMemory.GoPreviousAddress();
        }
    }
}