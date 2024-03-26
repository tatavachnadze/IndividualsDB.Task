namespace TBC.DTO
{
    public class Individual
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string PersonalNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public City City { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? HomeNumber { get; set; }
        public string? OfficeNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<IndividualRelations>? FromRelations { get; set; }
        public ICollection<IndividualRelations>? ToRelations { get; set; }
    }
    public enum Gender : byte
    {
        Male = 0,
        Female = 1,
    }
}
