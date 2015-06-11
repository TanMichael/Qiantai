
namespace QTsys.DataObjects
{
    class Material : QiaotaiObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Unit { get; set; }
        public int StockCount { get; set; }
    }
}
