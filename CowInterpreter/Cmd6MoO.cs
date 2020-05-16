namespace CowInterpreter {
    internal class Cmd6MoO : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.DataMemory.Value++;
        }
    }
}