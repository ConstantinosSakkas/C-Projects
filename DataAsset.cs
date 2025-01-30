
using System.Data.Linq;

namespace Draft_4//https://www.youtube.com/watch?v=w3_3E9cmND0 addionial linq implemetations 
{
    public class Asset1 : DataContext// contents for asset table placed in one class 
    {
        public Asset1(string connString) : base(connString) { }
        public Table<Asset> Assets => GetTable<Asset>();
        public Table<SoftAsset> SoftAssets => GetTable<SoftAsset>();
        internal void SaveChanges()//suggestion came from visual studio tool 
        {
            this.SubmitChanges();
        }
    }
}
