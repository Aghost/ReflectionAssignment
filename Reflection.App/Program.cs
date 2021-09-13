using System;
using System.IO;
using System.Dynamic;
using Reflection.Business;

namespace Reflection.App
{
    // System.Reflection.RuntimeAssembly
    class Program
    {
        static void Main(string[] args) {
            AssemblyService AS = new(Path.GetFullPath("ReflectThis.dll"));
        }
    }
}
