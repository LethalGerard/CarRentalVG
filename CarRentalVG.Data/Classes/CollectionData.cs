using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Data.Classes
{
    public class CollectionData : IData
    {        
        public void Add(IPerson inputCustomer) { _persons.Add(inputCustomer); }
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<VehicleInherit> _vehicles = new List<VehicleInherit>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
        public int NextPersonID => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        int IData.NextPersonID { get; set; }

        public CollectionData() => SeedData();

        private void SeedData()
        {
            //creating Vehicles
            Car car1 = new Car(1, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200, VehicleStatuses.Available);
            Car car2 = new Car(2, "DEF456", "SAAB", 20000, 1, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            Car car3 = new Car(3, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100, VehicleStatuses.Available);
            Car car4 = new Car(4, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available);
            Car car5 = new Car(5, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300, VehicleStatuses.Available);
            Motorcycles mc1 = new Motorcycles("MNO234", "Yamaha", 44945, 0.5, VehicleTypes.Motorcycle, 200, VehicleStatuses.Available);

            _vehicles.Add(car1);
            _vehicles.Add(car2);
            _vehicles.Add(car3);
            _vehicles.Add(car4);
            _vehicles.Add(car5);
            _vehicles.Add(mc1);
            
            //creating customers
            Customer customer1 = new Customer(1, 780925, "Göran", "Grenmoss");
            Customer customer2 = new Customer(2, 051025, "Al", "Kis");
            Customer customer3 = new Customer(3, 980905, "Sara", "Lastman");
            Customer customer4 = new Customer(4, 442211, "Inga-Britt", "Bäckermo");

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


        public void AddCustomer(int id, int ssn, string firstName, string lastName)
        {
            _persons.Add(new Customer(id, ssn, firstName, lastName));
        }

        public void AddVehicleAsync(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, int costDay, VehicleStatuses vehicleStatus)
        {            
           if (vehicleType == VehicleTypes.Motorcycle)
           {
              _vehicles.Add(new Motorcycles(regNo, make, odometer, costKm, vehicleType, costDay, vehicleStatus));
           }
           else
           {
              _vehicles.Add(new Car(id, regNo, make, odometer, costKm, vehicleType, costDay, vehicleStatus));
           }           
        }





        public IEnumerable<IPerson> GetCustomer() => _persons;
        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default) => _vehicles;

        IEnumerable<IPerson> IData.GetCustomer()
        { return _persons; }

        IEnumerable<VehicleInherit> IData.GetVehicles(VehicleStatuses status)
        { return _vehicles; }

        IEnumerable<IBooking> IData.GetBookings()
        { return _bookings; }
    }
}