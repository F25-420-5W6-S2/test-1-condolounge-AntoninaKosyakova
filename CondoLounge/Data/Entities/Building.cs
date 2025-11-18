namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public string BuildingId { get; set; } =  default!;

        public string Name { get; set; } = default!;

        public ICollection<Condo> Condos { get; set; } = new List<Condo>();
    }
}
