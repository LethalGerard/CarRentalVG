using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Classes;
using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;

    public IEnumerable<IPerson> GetCustomer() { return _db.GetCustomer(); }
    public IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default) { return _db.GetVehicles(status); }
    public IEnumerable<IBooking> GetBookings() { return _db.GetBookings(); }

    public Customer c = new();
    public VehicleInherit v = new();
    // public Booking b = new();
    public string alertMessage = string.Empty;
    public Customer selectedCustomer = new();



    public void AddCustomer()
    {
        if (c.Ssn != 0 && c.FirstName != null && c.LastName != null)
        {
            int nextId = _db.NextPersonID;
            IPerson inputCustomer = new Customer(default, c.Ssn, c.FirstName, c.LastName) 
                                                { Id = nextId };
            _db.Add(inputCustomer);
            c.Ssn = 0;
            c.FirstName = "";
            c.LastName = "";
            alertMessage = "";
        }
        else 
        {
            alertMessage = "Check the input Customer fields!";
        }
    }

    public void AddVehicle()
    {
        if (v.RegNo != null && v.Make != null && v.Odometer != null && v.CostKm != null && v.VehicleType != null && v.CostDay != null)
        {
            VehicleInherit inputVehicle = new VehicleInherit(default, v.RegNo, v.Make, v.Odometer, v.CostKm, v.VehicleType, v.CostDay, default);
            _db.Add(inputVehicle);
            v.RegNo = "";
            v.Make = "";
            v.Odometer = 0;
            v.CostKm = 0;
            v.VehicleType = default;
            v.CostDay = 0;
            alertMessage = "";
        }
        else
        {
            alertMessage = "Check the input Vehicle fields!";
        }
    }

    public void SubmitBooking(VehicleInherit vehicleBook, IPerson customerBook)
    {
        Booking newBooking = 
            new Booking(vehicleBook, customerBook);
        _db.AddBooking(newBooking);
    }

}
