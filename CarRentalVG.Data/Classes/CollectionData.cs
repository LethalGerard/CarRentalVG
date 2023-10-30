using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public CollectionData() => SeedData();

        private void SeedData()
        {
            //creating Vehicles
            Car car1 = new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available);
            Car car2 = new Car("DEF456", "SAAB", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            Car car3 = new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            Car car4 = new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available);
            Car car5 = new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available);
            Motorcycles mc1 = new Motorcycles("MNO234", "Yamaha", 44945, 0.5, VehicleTypes.Motorcycle, 200, VehicleStatuses.Available);

            _vehicles.Add(car1);
            _vehicles.Add(car2);
            _vehicles.Add(car3);
            _vehicles.Add(car4);
            _vehicles.Add(car5);
            _vehicles.Add(mc1);

            //creating customers
            Customer customer1 = new Customer(780925, "Göran", "Grenmoss");
            Customer customer2 = new Customer(051025, "Al", "Kis");
            Customer customer3 = new Customer(980905, "Sara", "Lastman");
            Customer customer4 = new Customer(442211, "Inga-Britt", "Bäckermo");
            AddCustomer();
            _persons.Add(customer1);
            _persons.Add(customer2);
            _persons.Add(customer3);
            _persons.Add(customer4);


            //creating bookings
            Booking booking1 = new Booking(car1, customer1, car1.Odometer, DateTime.Now);
            Booking booking2 = new Booking(car2, customer2, car2.Odometer, DateTime.Now);

            _bookings.Add(booking1);
            _bookings.Add(booking2);

            booking1.ReturnVehicle(DateTime.Now, 10500);

        }

        public int Ssn { get; set; }
        public void AddCustomer(int ssn = 345233, string firstName = "Anna Holger", string lastName = "lastName")
        {
            _persons.Add(new Customer(ssn, firstName, lastName));
        }

        IEnumerable<IPerson> GetCustomer() => _persons;
        IEnumerable<IBooking> GetBookings() => _bookings;
        IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;

        IEnumerable<IPerson> IData.GetCustomer()
        {
            return _persons;
        }

        IEnumerable<IVehicle> IData.GetVehicles(VehicleStatuses status)
        {
            return _vehicles;
        }

        IEnumerable<IBooking> IData.GetBookings()
        {
            return _bookings;
        }
    }
}