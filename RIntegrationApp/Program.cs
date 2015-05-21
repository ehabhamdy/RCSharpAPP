using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;

namespace RIntegrationApp
{
    class Program
    {
        static void Main(string[] args)
        {        
            REngine.SetEnvironmentVariables(); // <-- May be omitted; the next line would call it.
            REngine engine = REngine.GetInstance();

            // .NET Framework array to R vector.
            NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });


            // Direct parsing from R script.
            NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

            //Calculating the mean of g1 and g2 vectors using (mean) R function

            engine.SetSymbol("g1", group1);
            engine.Evaluate("mean(g1)"); // print out in the console

            engine.SetSymbol("g2", group2);
            engine.Evaluate("mean(g2)"); // print out in the console
            

            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
            engine.Dispose();
        }
    }
}
