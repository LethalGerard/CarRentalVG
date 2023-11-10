using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace CarRentalVG.Data.Classes
{
    public class CollectionData : IData
    {
           private void AddVehicle(VehicleInherit? vehicleInherit)
        {
            throw new NotImplementedException();
        }

        public void Add(VehicleInherit inputVehicle) { _vehicles.Add(inputVehicle); }
        public void Add(IPerson inputCustomer) { _persons.Add(inputCustomer); }
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<VehicleInherit> _vehicles = new List<VehicleInherit>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
        public int NextPersonID => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        int IData.NextPersonID { get; set; }
        int IData.NextVehicleID { get; set; }
        public CollectionData() => SeedData();

        private void SeedData()
        {
            //creating Vehicles
            Car car1 = new Car(1, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, 200);
            Car car2 = new Car(2, "DEF456", "SAAB", 20000, 1, VehicleTypes.Sedan, 100);
            Car car3 = new Car(3, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, 100);
            Car car4 = new Car(4, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, 300);
            Motorcycles mc1 = new Motorcycles(1,"MNO234", "Yamaha", 44945, 0.5, VehicleTypes.Motorcycle, 200);

            _vehicles.Add(car1);
            _vehicles.Add(mc1);
            
            //creating customers
            Customer customer1 = new Customer(1, 780925, "Göran", "Grenmoss");

            _persons.Add(customer1);


            //creating bookings
/*            Booking booking1 = new Booking(car1, customer1, car1.Odometer, DateTime.Now);
            Booking booking2 = new Booking(car2, customer2, car2.Odometer, DateTime.Now);
*//*
            _bookings.Add(booking1);
            _bookings.Add(booking2);

*//*            booking1.ReturnVehicle(DateTime.Now, 10500);

*/        }

        public void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }


        public void AddCustomer(int id, int ssn, string firstName, string lastName)
        {
            _persons.Add(new Customer(id, ssn, firstName, lastName));
        }

        public void AddVehicleAsync(int id, string regNo, string make, int odometer, double costKm, VehicleTypes vehicleType, int costDay, VehicleStatuses vehicleStatus)
        {            
           if (vehicleType == VehicleTypes.Motorcycle)
           {
              _vehicles.Add(new Motorcycles(id, regNo, make, odometer, costKm, vehicleType, costDay));
           }
           else
           {
              _vehicles.Add(new Car(id, regNo, make, odometer, costKm, vehicleType, costDay));
           }           
        }

        public List<T> Get<T>(Expression<Func<T, bool>>? expression)
        {
            FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType ==typeof(List<T>));
            if (info is not null)
            {
                var list = (List<T>)info.GetValue(this);
                if(expression is not null)
                {
                    list = list.Where(expression.Compile()).ToList();
                }
                return list;
            }
            else
            {
                throw new InvalidOperationException("Could not find list!");
            }
            
        }
        public T? Single<T>(Expression<Func<T, bool>>? expression)
        {
            FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
            if (info is not null)
            {
                var list = (List<T>)info.GetValue(this);
                var item = list.SingleOrDefault(expression.Compile());
                return item;
            }
            else
            {
                throw new InvalidOperationException("Could not find type!");
            }

        }

        public async Task Add<T>(T item)
        {
            await Task.Delay(5000);
            try
            {
                FieldInfo? info = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.FieldType == typeof(List<T>));
                if (info is not null && item is not null)
                {
                    var list = (List<T>)info.GetValue(this);
                    list.Add(item);
                }
                else
                {
                    throw new ArgumentNullException("Could not add item!");
                }

            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public IEnumerable<IPerson> GetCustomer(IPerson? person) => _persons;
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