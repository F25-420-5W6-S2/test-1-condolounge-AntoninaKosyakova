using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data.Entities
{
    //One user may have multiple condos in multiple buildings.
    //Usually there is at least one user that leaves in a condo.
    public class ApplicationUser : IdentityUser<int>
    {
        //i think identity already gives an id so no id by me

        public ICollection<Condo> Condos { get; set; } = new List<Condo>();

        //public ICollection<Building> Buildings { get; set; } = new List<Building>;

        // Foreign key to the Condo the user belongs to
        //public string CondoNumber { get; set; } = default!;
    }
}
