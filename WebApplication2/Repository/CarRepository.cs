using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication2.Models;
using WebApplication2.Models.Dtos;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication2.Repository;

public class CarRepository : CommonRepository<Car>
{

    List<Car> cars = new List<Car>()
    {
        new Car(1,1,1,1,"Var",155000,2008,"34 AG 34","BMW","E30",2000),
        new Car(2,2,2,1,"Var",10000,2020,"34 BM 35","Toyota","Carolla",1000),
        new Car(3,2,3,3,"Yok",25000,2021,"34 AD 36","Ford","Mustang",3000),
        new Car(4,2,2,2,"Var",255000,2020,"34 RM 38","Audi","Q7",2000),
        new Car(5,4,3,2,"Yok",3450,2022, "34 ZZ 34", "Tesla","Model 3",3000),
        new Car(6,5,2,1,"Var",2200,2021, "06 AB 123","Ford","Focus", 1500),
        new Car(7,1,1,3,"Var",33000,2023, "34 GH 123","Volkswagen", "Passat", 2500),
        new Car(8,3,3,1,"Yok",22500,2020, "34 XYZ 789","BMW","X5", 3000),
    };
    List<Color> colors = new List<Color>()
{
    new Color(1,"Siyah"),
    new Color(2,"Beyaz"),
    new Color(3,"Gri"),
    new Color(4,"Lacivert"),
    new Color(5,"Kırmızı")
};
    List<Fuel> fuels = new List<Fuel>()
        {
            new Fuel(1,"Benzin"),
            new Fuel(2,"Dizel"),
            new Fuel(3,"Elektrikli"),
            new Fuel(4,"Hibrit"),
        };

    List<Transmission> transmissions = new List<Transmission>()
        {
            new Transmission(1,"Manuel"),
            new Transmission(2,"Otomatik"),
            new Transmission(3,"Yarı Otomatik"),
        };
    public override Car Add(Car created)
    {
        cars.Add(created);
        return created;
    }

    public override List<Car> GetAll()
    {
        return cars;
    }

    public override Car GetById(int id)
    {
        return cars.FirstOrDefault(c => c.Id == id);
    }

    public override Car Remove(int id)
    {
        Car? deletedCar = GetById(id);
        cars.Remove(deletedCar);
        return deletedCar;
    }

    public override Car Update(Car updated)
    {
        var newCar = cars.FirstOrDefault(c => c.Id == updated.Id);
        if (newCar != null)
        {
            newCar.ColorId = updated.ColorId;
            newCar.FuelId = updated.FuelId;
            newCar.TransmissionId = updated.TransmissionId;
            newCar.CarState = updated.CarState;
            newCar.KiloMeter = updated.KiloMeter;
            newCar.ModelYear = updated.ModelYear;
            newCar.Plate = updated.Plate;
            newCar.BrandName = updated.BrandName;
            newCar.ModelName = updated.ModelName;
            newCar.DailyPrice = updated.DailyPrice;

            return newCar;
        }
        return null;
    }

    public List<CarDetailDto> GetAllDetails()
        {
            var result =
                from c in cars
                join f in fuels on c.FuelId equals f.Id
                join t in transmissions on c.TransmissionId equals t.Id
                join cl in colors on c.ColorId equals cl.Id
                select new CarDetailDto
                {
                    Id = c.Id,
                    FuelName = f.Name,
                    TransmissionName = t.Name,
                    ColorName = cl.Name,
                    CarState = c.CarState,
                    KiloMeter = c.KiloMeter,
                    ModelYear = c.ModelYear,
                    Plate = c.Plate,
                    BrandName = c.BrandName,
                    ModelName = c.ModelName,
                    DailyPrice = c.DailyPrice
        };

        return result.ToList();
    }

    public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.FuelId == fuelId 
            select new CarDetailDto { 
                             Id = c.Id,
                             FuelName = f.Name,
                             TransmissionName = t.Name,
                             ColorName = cl.Name,
                             CarState = c.CarState,
                             KiloMeter = c.KiloMeter,
                             ModelYear = c.ModelYear,
                             Plate = c.Plate,
                             BrandName = c.BrandName,
                             ModelName = c.ModelName,
                             DailyPrice = c.DailyPrice
                         };

        return result.ToList();
    }
    public List<CarDetailDto> GetAllDetailsByColorId(int colorId)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where cl.Id == colorId
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.ToList();
    }
    public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.DailyPrice <= max && c.DailyPrice >= min
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.ToList();
    }
    public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.BrandName == brandName
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.ToList();
    }

    public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.ModelName == modelName
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.ToList();
    }
    public CarDetailDto? GetDetailById(int categoryId)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.Id == categoryId
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.FirstOrDefault();
    }

    public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
    {
        var result =
            from c in cars
            join f in fuels on c.FuelId equals f.Id
            join t in transmissions on c.TransmissionId equals t.Id
            join cl in colors on c.ColorId equals cl.Id
            where c.KiloMeter <= max && c.KiloMeter >= min
            select new CarDetailDto
            {
                Id = c.Id,
                FuelName = f.Name,
                TransmissionName = t.Name,
                ColorName = cl.Name,
                CarState = c.CarState,
                KiloMeter = c.KiloMeter,
                ModelYear = c.ModelYear,
                Plate = c.Plate,
                BrandName = c.BrandName,
                ModelName = c.ModelName,
                DailyPrice = c.DailyPrice
            };

        return result.ToList();
    }
}
