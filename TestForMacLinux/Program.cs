using CommandLine;
using System;
using System.Reflection;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Generic;

namespace Altseed2.TestForMacLinux
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);
            if (result.Tag == ParserResultType.NotParsed)
            {
                Console.Write((NotParsed<Options>)result);
                return -1;
            }

            var options = ((Parsed<Options>)result).Value;

            // if you test specific cases in code, you add filter.
            // options.Filter = new List<string> { "Sound" };
#if CI
            options.Filter = new List<string> { "-Sound" };
#endif

            bool isSuccessful = true;
            var testProjctAssembly = typeof(Test.Window).Assembly;
            foreach (var classType in testProjctAssembly.GetTypes().Where(obj => Attribute.GetCustomAttribute(obj, typeof(TestFixtureAttribute)) != null))
            {
                var instance = Activator.CreateInstance(classType);
                foreach (var method in classType.GetMethods())
                {
                    if (!ShouldRun(options, classType, method)) continue;

                    try
                    {
                        Console.WriteLine(classType.Name + "." + method.Name);
                        var sw = new Stopwatch();
                        sw.Start();
                        method.Invoke(instance, null);
                        sw.Stop();
                        Console.WriteLine("Success " + sw.ElapsedMilliseconds + "ms");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(e.InnerException);
                        Console.WriteLine("");
                        Console.WriteLine("Fail");
                        isSuccessful = false;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    Console.WriteLine("");
                }
            }

            return isSuccessful ? 0 : -1;
        }

        private static bool ShouldRun(Options options, Type type, MethodInfo method)
        {
            if (Attribute.GetCustomAttribute(method, typeof(TestAttribute)) == null) return false;

            // フィルタが1つもなければすべて true
            if (!options.Filter.Any()) return true;
            var name = $"{type.Name}.{method.Name}";

            // 指定フィルタ
            if (!options.Filter.Where(f => !f.StartsWith('-')).All(f => name.Contains(f))) return false;

            // 除外フィルタ
            if (options.Filter.Where(f => f.StartsWith('-')).Any(f => name.Contains(f.Substring(1)))) return false;

            return true;
        }
    }
}
