namespace CowInterpreter {
    internal class Cmd5MOo : Cmd {
        public override void Execute(Cpu cpu) {
            cpu.DataMemory.Value--;
        }
    }
}