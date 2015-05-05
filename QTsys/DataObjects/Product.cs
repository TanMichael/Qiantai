
namespace QTsys.DataObjects
{
    public class Product : QiaotaiObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public string Texture { get; set; }
        public string Shift { get; set; }
        public string RealShift { get; set; }
        public string Temperate { get; set; }
        public string ElapsedTime { get; set; }
        public string Presure { get; set; }
        public string ResinName { get; set; }
        public string ResinProportion { get; set; }
        public string Soak { get; set; }
        public string Outsize { get; set; }
        public string Jig { get; set; }
        public string Weight { get; set; }
        public string Formingdie{ get; set; }
        public string ModingNum{ get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
    }
}
