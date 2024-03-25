namespace TBC.DTO
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Individual>? Individuals { get; set; }
    }
}
