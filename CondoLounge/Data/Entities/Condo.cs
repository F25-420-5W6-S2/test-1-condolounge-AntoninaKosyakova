namespace CondoLounge.Data.Entities
{
    //One condo can have multiple users and the Condo-Number is mandatory and uniq id in the same building.

    public class Condo
    {
        //an instance of a condo should have only one building it is attached to... so FK to building
        public string BuildingId { get; set; } = default!;
        public string CondoNumber { get; set; } = default!;

        //A condo will have: CondoNumber, location/ address.
        public string Address { get; set; } = default!;

        public Building? Building { get; set; }

        ///Usually there is at least one user that lives in a condo.
        //but One condo can have multiple users
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        
   

        
    }
}
