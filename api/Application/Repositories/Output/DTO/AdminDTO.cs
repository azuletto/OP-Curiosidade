namespace Application.Output.DTO
{
    public struct AdminDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string? Password { get; set; }
    }
}
