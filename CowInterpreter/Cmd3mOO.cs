namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd3mOO : Cmd {
        public override void Execute(Cpu cpu) {
            var cmd = GetCommand((Cmds)cpu.DataMemory.Value);
            cmd.Execute(cpu);
        }
    }
}