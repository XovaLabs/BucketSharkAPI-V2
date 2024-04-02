using System.Numerics;

namespace BucketSharkAPI
{
    public class Category
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public decimal Budgeted { get; set; }
        public decimal Spent { get; set; }
        public decimal Balance { get; set; }
    }
}
