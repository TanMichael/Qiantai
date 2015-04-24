
namespace QTsys.DataObjects
{
    class CustomerMember : JsonObjectBase<User>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }
      
    }
}
