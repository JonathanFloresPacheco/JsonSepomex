using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadJson01
{
    class Program
    {
        public static PropiedasdesJson rdJson = new PropiedasdesJson();
        static void Main(string[] args)
        {

            try
            {
                //List<listpropiedades> sepoList = new List<listpropiedades>();
                //Leemos el directorio en busca de archivos
                DirectoryInfo d = new DirectoryInfo("C:\\tuvotocuenta\\Archivos\\Json");
                //Instancia de XML
                //XmlDocument xDoc = new XmlDocument();
                //XmlNode VlDirXml, VlDirXml2;
                foreach (FileInfo file in d.GetFiles())
                {
                    String archivo = Convert.ToString(file.Name);
                    //lbArchivo.Text += archivo + " | ";
                    Console.WriteLine("Seleccione el menu");
                    Console.WriteLine("1.- Entidad Federativa        2.-Municipio        3.-Salir");
                    Console.WriteLine("Ingrese el numero a elegir:");
                    string path = @"C:\tuvotocuenta\Archivos\Json\" + archivo;
                    int Res =Convert.ToInt32(Console.ReadLine());
                    switch(Res)
                    {
                        case 1:
                            string RetVal0= rdJson.BusquedaporEntidad(path, "Aguascalientes");
                            Console.WriteLine("Valores: ");
                            Console.WriteLine(RetVal0);
                            Console.WriteLine("******************************************************");
                            Console.ReadLine();
                            break;
                        case 2:
                            string RetVal1 = rdJson.BusquedaporMunicipio(path, "Nahuatzen");
                            Console.WriteLine(RetVal1);
                            Console.WriteLine("******************************************************");
                            Console.ReadLine();
                            break;
                        case 3:
                            break;
                    }
                }
            }
            catch (Exception erc)
            {
                Console.WriteLine("Error "+erc.Message);
            }
        }
    }
}
