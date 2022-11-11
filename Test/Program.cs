using Serilog;
using SolidWorks.Interop.sldworks;
using System;
using System.Windows;

namespace Converter
{
    internal class Program
    {
        private static SldWorks swApp;
        private static ModelDoc2 swModel;
        private static DrawingDoc swDraw;
        private static SelectionMgr swSelMgr;
        private static Note swNote;
        private static int errors, warnings;
        private static double Width, Height;

        private static void Main(string[] args)
        {
            //DBBuilder re = new DBBuilder();

            //re.SettingsForm();

            //swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            //string s = @"DXFs\<_FileName_>_<_FeatureName_>_<_ConfName_>_<$CLPRP:Description>.dxf";

            //Regex regex = new Regex(@"<[^>]*>");
            //MatchCollection matches = regex.Matches(s);
            //if (matches.Count > 0)
            //{
            //    foreach (Match match in matches)
            //        Console.WriteLine(match.Value);
            //}
            //else
            //{
            //    Console.WriteLine("Совпадений не найдено");
            //}

            Loger();

            Console.ReadKey();
        }

        static void Loger()
        {
            Console.WriteLine("Strart log");
            Log.Logger =  new LoggerConfiguration()

                .MinimumLevel.Debug()
                //.WriteTo.File("logs/myapp.txt")
                .CreateLogger();

            Log.Information("Hello, world!");
            Console.WriteLine("Hello");
            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}