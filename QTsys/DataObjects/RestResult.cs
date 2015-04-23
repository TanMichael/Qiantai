
namespace QTsys.DataObjects
{
    class RestResult: JsonObjectBase<RestResult>
    {
        public string Status { get; set; }
        public string ResultJson { get; set; }
        public string Message { get; set; }
    }
}
