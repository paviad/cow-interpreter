using System;

namespace CowInterpreter {
    // ReSharper disable once InconsistentNaming
    internal class Cmd11oom : Cmd {
        public override void Execute(Cpu cpu) {
            Console.WriteLine("Enter a number");
            var num = Convert.ToInt32(Console.ReadLine());
            cpu.DataMemory.Value = num;
        }
    }
}