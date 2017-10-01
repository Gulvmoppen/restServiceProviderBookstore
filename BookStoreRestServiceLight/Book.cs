using System.Runtime.Serialization;

namespace BookStoreRestServiceLight
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}