using System; 
using System.Data; 

namespace FitbitHeartRateImporter.Models
{
    internal class ActivitiesHeartIntraday
    {
        //public IntradayActivitiesHeart ActivitiesHeart { get; set; }
        //public List<DatasetInterval> Dataset { get; set; }
        public int DatasetInterval { get; set; }
        public string DatasetType { get; set; }

        //// Init dataSet
        //internal ActivitiesHeartIntraday()
        //{
        //    DataSet = new DataSet("dataset") { Namespace = "NetFrameWork" };
        //    var dataTable = new DataTable();

        //    var timeColumn = new DataColumn("time", typeof(DateTime));
        //    var valueColumn = new DataColumn("value", typeof(int));
        //    dataTable.Columns.Add(timeColumn);
        //    dataTable.Columns.Add(valueColumn);

        //    DataSet.Tables.Add(dataTable);
        //}

        //public DataSet DataSet { get; set; }
        //public int DataSetInternal { get; set; }
        //public string DataSetType { get; set; } // Could be a enum? Example value is "minute"
    }
}
