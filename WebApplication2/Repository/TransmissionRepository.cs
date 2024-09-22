using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class TransmissionRepository : CommonRepository<Transmission>
    {
        List<Transmission> transmissions = new List<Transmission>()
        {
            new Transmission(1,"Manuel"),
            new Transmission(2,"Otomatik"),
            new Transmission(3,"Yarı Otomatik"),
        };
        public override Transmission Add(Transmission created)
        {
            transmissions.Add(created);
            return created;
        }

        public override List<Transmission> GetAll()
        {
            return transmissions;
        }

        public override Transmission GetById(int id)
        {
            return transmissions.FirstOrDefault(t => t.Id == id);    
        }

        public override Transmission Remove(int id)
        {
            Transmission deletedTransmission = GetById(id);
            transmissions.Remove(deletedTransmission);
            return deletedTransmission;
        }

        public override Transmission Update(Transmission updated)
        {
            var newTransmission = transmissions.FirstOrDefault(t=>t.Id == updated.Id);
            if(newTransmission != null)
            {
                newTransmission.Id = updated.Id;
                newTransmission.Name = updated.Name;
                return newTransmission;
            }
            return null;
        }
    }
}
