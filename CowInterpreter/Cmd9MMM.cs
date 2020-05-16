namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd9MMM : Cmd {
        public override void Execute(Cpu cpu) {
            if (cpu.Register.HasValue) {
                cpu.DataMemory.Value = cpu.Register.Value;
                cpu.Register = null;
            }
            else {
                cpu.Register = cpu.DataMemory.Value;
            }
        }
    }
}