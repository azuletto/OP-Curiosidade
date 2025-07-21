namespace OpCuriosidade.Entities.PersonnelContext.ValueObjects
{
    public class OtherInfos
    {
        public OtherInfos(string? valors, string? feelings, string? info, string? interess)
        {
            Valors = valors;
            Feelings = feelings;
            Info = info;
            Interess = interess;
        }

        public string? Valors { get; set; }
        public string? Feelings { get; set; }
        public string? Info { get; set; }
        public string? Interess { get; set; }
    }
}
