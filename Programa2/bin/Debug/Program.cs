//&p-Programa4
//&b=38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa_5
{
    class Program
    {
        //&i
        static void Main(string[] args)
        {
            // Atributos
            double dX = 0;
            double dE = 0.000000001; // Error
            int iDof = 0; // Grados de libertad
            double dP = 0; // added

            // Obtener dP
            String sInput = Console.ReadLine();
            try
            {
                dP = Double.Parse(sInput); //&m
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el dato introducido");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (dP < 0 || dP > 0.5) //&m
            {
                Console.WriteLine("Error en el dato introducido");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Obtener iDof
            sInput = Console.ReadLine();
            try
            {
                iDof = int.Parse(sInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Error en el dato introducido");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (iDof <= 0)
            {
                Console.WriteLine("Error en el dato introducido");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Numero de segmentos por default = 10
            int iNum_Seg = 1000;

            //&d=9
            dX = 1;
            
            // test simpson
            Simpson simpsonT = new Simpson(dX, iDof, iNum_Seg);
            double CorrigeX = simpsonT.calcularP() - dP;
            double correccion = 0.5;
            char changesimbol = '-'; // p = positive, n = negative

            if (simpsonT.calcularP() != dP)
            {
                if (CorrigeX > 0)
                {
                    dX -= correccion;
                    changesimbol = 'p';
                }
                else if (CorrigeX < 0)
                {
                    dX += correccion;
                    changesimbol = 'n';
                }
                simpsonT = new Simpson(dX, iDof, iNum_Seg);
                CorrigeX = simpsonT.calcularP() - dP;
            }

            while (Math.Abs(CorrigeX) > dE)
            {
                if (CorrigeX > 0)
                {
                    if (changesimbol == 'n')
                    {
                        correccion /= 2;
                        changesimbol = 'p';
                    }
                    dX -= correccion;                  
                }
                else if (CorrigeX < 0)
                {
                    if (changesimbol == 'p')
                    {
                        correccion /= 2;
                        changesimbol = 'n';
                    }
                    dX += correccion;
                }
                simpsonT = new Simpson(dX, iDof, iNum_Seg);
                CorrigeX = simpsonT.calcularP() - dP;
            }           

            // Print
            Console.WriteLine("P = " + string.Format("{0:N5}", dP)); //&m
            Console.WriteLine("dof = " + iDof);
            Console.WriteLine("x = " + string.Format("{0:N5}", Math.Round(dX, 5))); //&m
            Console.ReadLine();
        }
    }
}
