using System;
using System.Collections.Generic;
using System.Globalization;

namespace CowInterpreter {
    internal class Memory {
        private readonly LinkedList<int> _mem = new LinkedList<int>();
        public int Address { get; private set; }
        public int Value {
            get => Current.Value;
            set => Current.Value = value;
        }

        public bool IsFrozen { get; private set; }

        public int Size { get; set; }
        public LinkedListNode<int> Current { get; set; }

        public Memory() {
            Size = 1;
            _mem.AddFirst(0);
            Current = _mem.First;
        }

        public int GoNextAddress() {
            if (Current.Next == null) {
                if (IsFrozen) {
                    throw new InvalidOperationException("Frozen");
                }
                _mem.AddLast(0);
                Size++;
            }
            Current = Current.Next;
            Address++;
            return Value;
        }

        public int GoPreviousAddress() {
            if (Current.Previous == null) {
                if (IsFrozen) {
                    throw new InvalidOperationException("Frozen");
                }
                _mem.AddFirst(0);
                Size++;
            }

            Current = Current.Previous;
            Address--;
            return Value;
        }

        public void Freeze() {
            IsFrozen = true;
        }

        public void Print(bool commands = false) {
            var n = Current;
            var a = Address;
            while (n.Previous != null) {
                n = n.Previous;
                a--;
            }

            var state = 0;
            const int perLine = 10;

            while (n != null) {
                if (state == 0) {
                    Console.Write($"{a,4}: ");
                }

                if (commands) {
                    Console.Write("{0,10}", (Cmds)n.Value);
                }
                else {
                    Console.Write("{0,10}", n.Value);
                }

                state++;
                if (state == perLine) {
                    Console.WriteLine();
                    state = 0;
                }
                n = n.Next;
                a++;
            }

            if (state != 0) {
                Console.WriteLine();
            }
        }
    }
}