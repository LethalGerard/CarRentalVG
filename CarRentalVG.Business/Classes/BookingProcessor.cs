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

    public void AddCustomer()
    {
        if (c.Ssn != null && c.FirstName != null && c.LastName != null)
        {
            int nextId = _db.NextPersonID;
            IPerson inputCustomer = new Customer(default, c.Ssn, c.FirstName, c.LastName) 
                                                { Id = nextId };
            _db.Add(inputCustomer);
        }        

    }

}