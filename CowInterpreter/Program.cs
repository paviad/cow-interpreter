using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CowInterpreter {
    internal class Program {
        private static void Main() {
            // Read sample programs from file `SamplePrograms.txt`
            var (programNames, samplePrograms) = ReadSamplePrograms();

            // Don't hate goto!
            again:

            var cpu = new Cpu();

            // Display a menu and get user selection.
            var selectedOption = GetUserMenuSelection(programNames, samplePrograms);

            string pgm;
            if (selectedOption == 0) {
                pgm = ReadProgramFromInput();
            }
            else {
                var pgmName = programNames[selectedOption - 1];
                pgm = samplePrograms[pgmName];
                Console.WriteLine($"Loading program {pgmName}:\n\n{pgm}\n");
            }

            // Compile program into the cpu's program memory as byte-code.
            cpu.CompileProgram(pgm);
            try {
                cpu.RunProgram();
                Console.WriteLine();
            }
            catch (Exception) {
                Console.WriteLine($"Error: Program counter out of bounds at address {cpu.ProgramAddress}");
            }

            cpu.Print();

            Console.WriteLine("Again? [y/n]");

            if (Console.ReadKey().KeyChar == 'y') {
                Console.WriteLine();
                goto again;
            }
        }

        private static int GetUserMenuSelection(List<string> programNames, Dictionary<string, string> samplePrograms) {
            var selectedOption = -1;
            Console.WriteLine("Select from these options:\n");
            Console.WriteLine("0. Enter your own program");
            for (var i = 0; i < samplePrograms.Count; i++) {
                Console.WriteLine($"{i + 1}. Load and run {programNames[i]}");
            }

            do {
                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.KeyChar == '0') {
                    selectedOption = 0;
                }
                else {
                    var indexOf = (uint)"123456789".IndexOf(key.KeyChar);
                    if (indexOf < samplePrograms.Count) {
                        selectedOption = (int)indexOf + 1;
                    }
                }

                if (selectedOption == -1) {
                    Console.WriteLine("Must select a menu option");
                }
            } while (selectedOption == -1);

            return selectedOption;
        }

        private static (List<string> programNames, Dictionary<string, string> samplePrograms) ReadSamplePrograms() {
            var samplePrograms = new Dictionary<string, string>();
            var programNames = new List<string>();
            var lines = File.ReadAllLines("SamplePrograms.txt");
            var state = 0;
            var programName = "";
            var programSource = "";

            int State(string line) {
                var emptyLine = string.IsNullOrWhiteSpace(line);
                switch (state) {
                    case 0:
                        if (emptyLine) {
                            goto nextLine; // Don't hate it...
                        }

                        programName = line;
                        programSource = "";
                        state = 1;

                        break;
                    case 1:
                        if (emptyLine) {
                            goto nextLine;
                        }

                        programSource += line + " ";
                        state = 2;
                        break;
                    case 2:
                        if (emptyLine) {
                            state = 0;
                            var trimmed = Regex.Replace(programSource, @"\s+", " ").Trim();
                            samplePrograms[programName] = trimmed;
                            programNames.Add(programName);
                            goto nextLine;
                        }

                        programSource += line + " ";
                        break;
                }

                nextLine:
                return state;
            }

            foreach (var l in lines) {
                state = State(l);
            }

            // Treat file as if there's an empty line at the end.
            State("");

            return (programNames, samplePrograms);
        }

        private static string ReadProgramFromInput() {
            var pgm = "";
            string line;
            do {
                line = Console.ReadLine();
                pgm += line;
            } while (!string.IsNullOrWhiteSpace(line));

            return pgm;
        }
    }
}
