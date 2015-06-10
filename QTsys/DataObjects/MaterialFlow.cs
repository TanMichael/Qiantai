
using System;
namespace QTsys.DataObjects
{
    class MaterialFlow : QiaotaiObject
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int MaterialId { get; set; }
        public int FlowCount { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
        public DateTime OccurredTime { get; set; }
        public int OperatorId { get; set; }
        public string Operator { get; set; }
    }
}
