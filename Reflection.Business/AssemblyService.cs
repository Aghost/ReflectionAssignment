using System;
using System.Linq;
using System.Reflection;

using static System.Console;

namespace Reflection.Business
{
    public class AssemblyService
    {
        private readonly string Path;
        private readonly Assembly asm;

        public AssemblyService(string path) {
            Path = path;
            asm = Assembly.LoadFile(Path);
            GetAllAssemblyItems();
        }

        public void GetAllAssemblyItems() {
            foreach (var v in asm.GetTypes()) {
                WriteLine($"Hello, i am {v}, my basetype is {v.BaseType}.");

                var attribs = v.Attributes.ToString().Split(" ").Reverse().ToArray();

                for (int i = attribs.Length - 1; i >= 0; i--) {
                    switch (attribs[i]) {
                        case "Class,": Write($"I am a Class, "); break;
                        case "AnsiClass,": Write($"I am an AnsiClass, "); break;
                        case "Public,": Write($"I am Public, "); break;
                        case "Sealed,": Write($"I am Sealed, "); break;
                        case "BeforeFieldInit": Write($"i have Beforefieldinit, "); break;
                        case "AutoLayout,": Write($"I have AutoLayout, "); break;
                        case "NestedPrivate,": Write($"I am NestedPrivate, "); break;
                        default: Write($"I dont know what i am {attribs[i]}, "); break;
                    }
                    if(i == 0) { WriteLine("and thats about it.\n"); }
                }

                WriteLine($"My Constructors:");
                foreach(var ctr in v.GetConstructors()) {
                    WriteLine($"\t- {ctr.Name}");

                }

                WriteLine($"My Fields:");
                foreach(var field in v.GetFields()) {
                    WriteLine($"\t- {field}");
                }

                WriteLine($"---");

            }
        }
    }
}
