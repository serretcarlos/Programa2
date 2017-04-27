using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programa2
{
    class Controller
    {
        private int iTotalLDC;//total de líneas de código de todos los archivos
        List<Parte> listPartes;
        string sCadenaArchivos;

        public Controller(string sCadenaArchivos)
        {
            this.sCadenaArchivos = sCadenaArchivos;
            iTotalLDC = 0;
        }
        
        public void ProcesarArchivos()
        {
            string sParte = "//&p-";
            string sItem = "//&i";
            string sBase = "//&b=";
            string sBorradas = "//&d=";
            string sModificadas = "//&m";
            string sComentario = "//";

            StreamReader entrada = null;
            bool bAbierto;
            listPartes = new List<Parte>();
            
            string[] sArrArchivos = sCadenaArchivos.Split(' ');
            foreach (string archivo in sArrArchivos)
            {
                bAbierto = false;
                try
                {
                    entrada = File.OpenText(archivo);
                    bAbierto = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (bAbierto)
                {
                    Parte parte = new Parte();
                    string sLinea = entrada.ReadLine();
                    while (sLinea != null)
                    {
                        if (sLinea.IndexOf("/*") >= 0)
                        {
                            if (sLinea.IndexOf("*/") >= 0)
                            {
                                // do nothing
                            }
                            else
                            {
                                while (sLinea != null && sLinea.IndexOf("*/") < 0)
                                {
                                    sLinea = entrada.ReadLine();
                                }
                            }
                        }
                        else if (sLinea.IndexOf(sParte) >= 0)
                        {
                            parte = new Parte();
                            parte.Nombre = sLinea.Substring(sLinea.IndexOf(sParte) + 5);
                            sLinea = entrada.ReadLine();
                            while (sLinea != null && sLinea.IndexOf(sParte) < 0)
                            {
                                if (sLinea.IndexOf(sItem) >= 0)
                                {
                                    parte.Items++;
                                }
                                else if (sLinea.IndexOf(sBase) >= 0)
                                {
                                    string test = sLinea.Substring(sLinea.IndexOf(sBase) + 5);
                                    parte.IBase += int.Parse(sLinea.Substring(sLinea.IndexOf(sBase) + 5));
                                }
                                else if (sLinea.IndexOf(sBorradas) >= 0)
                                {
                                    parte.Borradas += int.Parse(sLinea.Substring(sLinea.IndexOf(sBorradas) + 5));
                                }
                                else if (sLinea.IndexOf("/*") >= 0)
                                {
                                    while (sLinea != null && sLinea.IndexOf("*/") < 0)
                                    {
                                        sLinea = entrada.ReadLine();
                                    }
                                }
                                else if ((sLinea.Trim() == "{") || (sLinea.Trim() == "}"))
                                {
                                    //do nothing
                                }
                                else if (sLinea.IndexOf(sComentario) < 0 && !String.IsNullOrWhiteSpace(sLinea))
                                {
                                    parte.Total++;
                                    iTotalLDC++;
                                    //Console.WriteLine(sLinea);
                                }
                                else if (sLinea.IndexOf(sComentario) > sLinea.IndexOf("'") && sLinea.IndexOf(sComentario) < sLinea.LastIndexOf("'"))
                                {
                                    parte.Total++;
                                    iTotalLDC++;
                                    //Console.WriteLine(sLinea);
                                }

                                if (sLinea.IndexOf(sModificadas) >= 0)
                                {
                                    int uno, dos;
                                    uno = sLinea.IndexOf("\"");
                                    dos = sLinea.LastIndexOf("\"");
                                    if (sLinea.IndexOf(sModificadas) > uno && sLinea.IndexOf(sModificadas) < dos)
                                    {
                                        //do nothing
                                    }
                                    else
                                    {
                                        parte.Modificadas++;
                                    }
                                    parte.Total++;
                                    iTotalLDC++;
                                    //Console.WriteLine(sLinea);
                                }
                                sLinea = entrada.ReadLine();
                            }
                            listPartes.Add(parte);
                        }
                        else if (sLinea.IndexOf(sComentario) < 0 && !String.IsNullOrWhiteSpace(sLinea) && !(sLinea.Trim() == "{") || (sLinea.Trim() == "}"))
                        {
                            parte.Total++;
                            iTotalLDC++;
                            //Console.WriteLine(sLinea);
                        }

                        if (sLinea != null)
                        {
                            if (sLinea.IndexOf(sParte) < 0)
                            {
                                sLinea = entrada.ReadLine();
                            }
                        }
                    }
                }
            }
            ImprimirResultados();
            entrada.Close();
        }

        public void ImprimirResultados()
        {
            StreamWriter salida = null;
            salida = File.CreateText("ConteoLDC.txt");
            salida.WriteLine("PARTES BASE:");
            Console.WriteLine("PARTES BASE:");
            string info;
            for (int i = 0; i < listPartes.Count; i++)
            {
                if (listPartes[i].IBase > 0 && (listPartes[i].Modificadas > 0 || listPartes[i].Borradas > 0 || (listPartes[i].Total - listPartes[i].IBase + listPartes[i].Borradas) > 0))
                {
                    info = listPartes[i].Nombre + ": T=" + listPartes[i].Total + " I=" + listPartes[i].Items + " B=" + listPartes[i].IBase +
                    " D=" + listPartes[i].Borradas + " M=" + listPartes[i].Modificadas + " A=" + (listPartes[i].Total - listPartes[i].IBase + listPartes[i].Borradas);
                    Console.WriteLine(info);
                    salida.WriteLine(info);
                }
            }

            salida.WriteLine("-----------------------------------------------\nPARTES NUEVAS:");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("PARTES NUEVAS:");
            for (int i = 0; i < listPartes.Count; i++)
            {
                if (listPartes[i].IBase == 0 && listPartes[i].Modificadas == 0 && listPartes[i].Borradas == 0 && (listPartes[i].Total - listPartes[i].IBase + listPartes[i].Borradas) > 0)
                {
                    info = listPartes[i].Nombre + ": T=" + listPartes[i].Total + " I=" + listPartes[i].Items;
                    Console.WriteLine(info);
                    salida.Write(info);
                }
            }

            salida.WriteLine("-----------------------------------------------\nPARTES REUSADAS:");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("PARTES REUSADAS:");
            for (int i = 0; i < listPartes.Count; i++)
            {
                if (listPartes[i].IBase > 0 && listPartes[i].Modificadas == 0 && listPartes[i].Borradas == 0 && (listPartes[i].Total - listPartes[i].IBase + listPartes[i].Borradas) == 0)
                {
                    info = listPartes[i].Nombre + ": T=" + listPartes[i].Total + " I=" + listPartes[i].Items + " B=" + listPartes[i].IBase;
                    Console.WriteLine(info);
                    salida.WriteLine(info);
                }
            }

            salida.WriteLine("-----------------------------------------------\nTotal de LDC = " + iTotalLDC);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Total de LDC = " + iTotalLDC);
            salida.Close();
            
        }

    }
}
