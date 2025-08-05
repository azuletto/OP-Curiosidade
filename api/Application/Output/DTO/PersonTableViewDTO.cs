namespace Application.Output.DTO
{
    public struct PersonTableViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Status { get; set; }
    }
}
