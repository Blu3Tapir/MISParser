using System;
using System.Collections.Generic;
using System.Text;

namespace MISP_JsonToDatasets
{
    class datasets
    {
        private string id = "";
        private string dataset_y = "";


        public datasets(string event_id, string y)
        {
            id = event_id;
            dataset_y = y;
        }

        public string output_format()
        {
            return dataset_y;
        }

        public string output_id()
        {
            return id;
        }

    }
}
