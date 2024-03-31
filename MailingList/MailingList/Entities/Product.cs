namespace MailingList.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPromotional { get; set; }
        public int SectionId { get; set; }
    }
}
