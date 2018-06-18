using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MercadoBitcoin.Classes
{
    public class OrdensJson
    {
        public List<Ordem> ListaOrdens;

        public OrdensJson(string json)
        {

            orderbookJson ordensAux = JsonConvert.DeserializeObject<orderbookJson>(json);

            /*DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            
            DataTable dataTable = dataSet.Tables["asks"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("aa");
            }*/


        }
    }
    public class OrdemJson
    {
        public DataSet Ordem { get; set; }
    }

    public class orderbookJson
    {
        public DataSet asks { get; set; }
        public DataSet bids { get; set; }

    }
}
