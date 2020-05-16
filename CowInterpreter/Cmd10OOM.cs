namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd10OOM : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.stdout.WriteLine("{0}", cpu.DataMemory.Value);
            cpu.stdout.Flush();
        }
    }
}