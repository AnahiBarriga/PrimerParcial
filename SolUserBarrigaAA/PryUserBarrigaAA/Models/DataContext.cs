namespace PryUserBarrigaAA.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
       public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PryUserBarrigaAA.Models.Form> Forms { get; set; }
    }
        
   
}
