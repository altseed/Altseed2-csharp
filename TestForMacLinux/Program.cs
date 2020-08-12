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
            options.Filter = new List<string> { "GaussianBlur" };
#if CI
            options.Filter = new List<string> { "-Sound" };
#endif

            bool isSuccessful = true;
            var testProjctAssembly = typeof(Test.Window).Assembly;
            foreach (var classType in testProjctAssembly.GetTypes().Where(obj => Attribute.GetCustomAttribute(obj, typeof(TestFixtureAttribute)) != null))
            {
                var instance = Activator.CreateInstance(classType);
                foreach (var method in classType.GetMethods()
                    .Where(obj => Attribute.GetCustomAttribute(obj, typeof(TestAttribute)) != null &&
                         (options.Filter.Count() == 0 ||
                         options.Filter.Where(cond => cond.FirstOrDefault() != '-').All(cond => (classType.Name + "." + obj.Name).Contains(cond)) &&
                         options.Filter.Where(cond => cond.FirstOrDefault() == '-').All(cond => !(classType.Name + "." + obj.Name).Contains(cond.TrimStart('-'))))))
                {
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
    }
}
