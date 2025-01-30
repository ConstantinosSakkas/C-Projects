using System;
using System.Data.Linq.Mapping;


namespace Draft_4 // Microsoft, Lists (https://learn.microsoft.com/en-us/answers/questions/1059982/get-subllist-from-a-list-in-c-linq-by-removing-few )(Accesed 1st November 2024) linq class and from CMP205 notes as well adapted to work with proect 
{
    //  mapp to the SoftAssets table
    [Table(Name = "GLEN.SoftAssets")]
    public class SoftAsset
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int SoftID { get; set; }//ID 

        [Column]
        public string OS { get; set; }//OS 

        [Column]
        public string Version { get; set; }//version

        [Column]
        public string Manufacturer { get; set; }//manufacturer

        [Column]
        public DateTime Date { get; set; }//current date 
    }

    
    [Table(Name = "GLEN.Assets")]  //Microsoft ,Linq(https://learn.microsoft.com/en-us/dotnet/api/system.data.linq.mapping.columnattribute.isdbgenerated?view=netframework-4.8.1/auto) (Accesed 3th October 2024) sync key for beter reading data and reduce the number of errors
    public class Asset
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int AssetID { get; set; } // primary key for AssetID

        [Column]
        public int EmpID { get; set; } // employee ID associated with employee

        [Column]
        public string IPAddress { get; set; } // IP address

        [Column]
        public string Notes { get; set; } // notes column 

        [Column]
        public int? SoftID { get; set; } // foreign key to SoftAsset
    }
}
