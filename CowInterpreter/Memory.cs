using System;
using System.Collections.Generic;

namespace CowInterpreter {
    internal class Memory {
        private readonly LinkedList<int> mem = new LinkedList<int>();
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
            mem.AddFirst(0);
            Current = mem.First;
        }

        public int GoNextAddress() {
            if (Current.Next == null) {
                if (IsFrozen) {
                    throw new InvalidOperationException("Frozen");
                }
                mem.AddLast(0);
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
                mem.AddFirst(0);
                Size++;
            }

            Current = Current.Previous;
            Address--;
            return Value;
        }

        public void Freeze() {
            IsFrozen = true;
        }
    }
}