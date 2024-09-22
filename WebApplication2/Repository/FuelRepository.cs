using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class FuelRepository : CommonRepository<Fuel>
    {
        List<Fuel> fuels = new List<Fuel>()
        {
            new Fuel(1,"Benzin"),
            new Fuel(2,"Dizel"),
            new Fuel(3,"Elektrikli"),
            new Fuel(4,"Hibrit"),
        };
        public override Fuel Add(Fuel created)
        {
            fuels.Add(created);
            return created;
        }

        public override List<Fuel> GetAll()
        {
            return fuels;
        }

        public override Fuel GetById(int id)
        {
            return fuels.FirstOrDefault(f=> f.Id == id);
        }

        public override Fuel Remove(int id)
        {
            Fuel? deletedFuel = GetById(id);
            fuels.Remove(deletedFuel);
            return deletedFuel;
        }

        public override Fuel Update(Fuel updated)
        {
            var newFuels = fuels.FirstOrDefault(f => f.Id == updated.Id);
            if(newFuels != null)
            {
                newFuels.Id = updated.Id;   
                newFuels.Name = updated.Name;
                return newFuels;
            }
            return null;
        }
    }
}
