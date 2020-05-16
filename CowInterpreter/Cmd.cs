using System;

namespace CowInterpreter {
    internal abstract class Cmd {
        public abstract void Execute(Cpu cpu);

        public static Cmds? GetCommand(string c) {
            Cmds cmd;
            switch (c) {
                case "moo":
                    cmd = Cmds.moo;
                    break;
                case "mOo":
                    cmd = Cmds.mOo;
                    break;
                case "moO":
                    cmd = Cmds.moO;
                    break;
                case "mOO":
                    cmd = Cmds.mOO;
                    break;
                case "Moo":
                    cmd = Cmds.Moo;
                    break;
                case "MOo":
                    cmd = Cmds.MOo;
                    break;
                case "MoO":
                    cmd = Cmds.MoO;
                    break;
                case "MOO":
                    cmd = Cmds.MOO;
                    break;
                case "OOO":
                    cmd = Cmds.OOO;
                    break;
                case "MMM":
                    cmd = Cmds.MMM;
                    break;
                case "OOM":
                    cmd = Cmds.OOM;
                    break;
                case "oom":
                    cmd = Cmds.oom;
                    break;
                default:
                    return null;
            }

            return cmd;
        }

        public static Cmd GetCommand(Cmds instruction) {
            Cmd cmd = instruction switch
            {
                Cmds.moo => new Cmd0moo(),
                Cmds.mOo => new Cmd1mOo(),
                Cmds.moO => new Cmd2moO(),
                Cmds.mOO => new Cmd3mOO(),
                Cmds.Moo => new Cmd4Moo(),
                Cmds.MOo => new Cmd5MOo(),
                Cmds.MoO => new Cmd6MoO(),
                Cmds.MOO => new Cmd7MOO(),
                Cmds.OOO => new Cmd8OOO(),
                Cmds.MMM => new Cmd9MMM(),
                Cmds.OOM => new Cmd10OOM(),
                Cmds.oom => new Cmd11oom(),
                _ => throw new ArgumentOutOfRangeException()
            };

            return cmd;
        }
    }
}