namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd2moO : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.DataMemory.GoNextAddress();
        }
    }
}