using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadJson01
{
    class PropiedasdesJson
    {
        public string D_mnpio { get; set; }
        public string D_estado { get; set; }
        public string D_zona { get; set; }


        public string BusquedaporEntidad(string path,string estado)
        {
            string tempValue = "";
            int Validacion = 0;
            JArray jsonResponse = JArray.Parse(File.ReadAllText(path));
            foreach (JObject content in jsonResponse.Children<JObject>())
            {
                Validacion = 0;
                foreach (JProperty prop in content.Properties())
                {

                    //if(prop.Name.Equals("d_estado") && prop.Value.Equals(estado))
                    //{
                    //    tempValue += prop.Value.ToString();                         
                    //}

                    if (prop.Name == "d_estado" && prop.Value.ToString() == estado || Validacion == 1)
                    {
                        if (Validacion == 0)
                        {
                            tempValue += prop.Value.ToString() + "|";
                            Validacion = 1;
                        }
                        else if (Validacion == 1)
                        {
                            tempValue += prop.Value.ToString() + "|";
                            Validacion = 2;
                        }
                    }
                }
            }
            return tempValue;
        }
        public string BusquedaporMunicipio(string path,string municipio)
        {
            string tempValue = "";
            int Validacion = 0;
            JArray jsonResponse = JArray.Parse(File.ReadAllText(path));
            foreach (JObject content in jsonResponse.Children<JObject>())
            {
                Validacion = 0;
                foreach (JProperty prop in content.Properties())
                {
                    if (prop.Name=="D_mnpio" && prop.Value.ToString()== municipio || Validacion == 1)
                    {
                        if(Validacion==0)
                        {
                            tempValue += prop.Value.ToString() + "|";
                            Validacion = 1;
                        }
                        else if(Validacion==1)
                        {
                            tempValue += prop.Value.ToString() + "|";
                            Validacion = 0;
                        }
                    }
                }
            }
            return tempValue;
        }
    }
}
