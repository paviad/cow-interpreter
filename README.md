# Cow Interpreter

To use this first create a `CPU` object:

```csharp
var cpu = new Cpu();
```

Then you can feed it program source as a `string`

```csharp
cpu.CompileProgram(pgm);
```

It will compile the program and store it in the CPU's program memory.

Then you can run the program:

```csharp
cpu.RunProgram();
```

After the program halts, you can print the program and data memory by calling `Print`:

```csharp
cpu.Print();
```

## Example

The file `Program.cs` reads several programs from a text file, and presents a menu for the user to run them.
