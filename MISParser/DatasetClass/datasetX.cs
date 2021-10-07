using System.Collections.Generic;


namespace MISP_TAG
{
    class datasetX
    {
        public string id { get; private set; } = "";
        public string type { get; private set; } = "";
        public string plainX { get; private set; } = "";
        public List<string> externalX { get; private set; } = new List<string>();


        public datasetX(string id, string type, string plainX)
        {
            this.id = id;
            this.type = type;
            this.plainX = plainX;
        }
        public void SetExternalX(List<string> SetX)
        {
            this.externalX = SetX;
        }
        public void SetExternalX(string setx)
        {
            externalX.Add(setx);
        }


    }
}
