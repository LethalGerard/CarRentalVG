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

    public IEnumerable<IPerson> GetCustomer() { return _db.Get<IPerson>(null); }
    public IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default) { return _db.Get<VehicleInherit>(null); }
    public IEnumerable<IBooking> GetBookings() { return _db.Get<IBooking>(null); }

    public Customer c = new();
    public VehicleInherit v = new();
    public Booking b = new();
    public string alertMessage = string.Empty;
    public Customer selectedCustomer = new();
    public int KmReturned {  get; set; }
    public double TotalCost { get; set; }
    public bool TaskDelayInProgress { get; private set; } = false;

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
            alertMessage = "Check the Customer input fields!";
        }
    }

    public void AddVehicle()
    {
        if (v.RegNo != null && v.Make != null && v.Odometer != null && v.CostKm != null && v.VehicleType != null && v.CostDay != null)
        {
            int nextId = _db.NextVehicleID;
            //VehicleInherit inputVehicle = new Vehicle()
            //{ Id = nextId };

            VehicleInherit inputVehicle = new VehicleInherit(default, v.RegNo, v.Make, v.Odometer, v.CostKm, v.VehicleType, v.CostDay);
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
            alertMessage = "Check the Vehicle input fields!";
        }
    }

    public async Task<IBooking> SubmitBooking(VehicleInherit vehicleBook, IPerson customerBook)
    {
        TaskDelayInProgress = true;
        alertMessage = "Processing the booking, please wait!";

        /*      var customers = _db.GetCustomer();
                var person = customers.FirstOrDefault(c => c.Ssn == customerBook.Ssn);
        */
        var customers = _db.GetCustomer();
        var person = customers.FirstOrDefault(c => c.Ssn == customerBook.Ssn);


        Booking newBooking = new Booking(vehicleBook, person);
        await Task.Delay(100);
        _db.AddBooking(newBooking);
        alertMessage = "";
        TaskDelayInProgress = false;
        return newBooking;
    }



/*    public void CalcCost(DateTime returnDate, DateTime pickupDate, int kmReturned)
    {
        var totDays = (returnDate - pickupDate).TotalDays;
        if (totDays < 1) { totDays = 1; }

        var distance = KmReturned - KmRented;

        TotalCost = totDays * Vehicle.CostDay + distance * Vehicle.CostKm;
    }
*/


    public void ReturnVehicle(VehicleInherit returnVehicle, int kmReturned)
    {
        var allVehicles = _db.GetVehicles();
        var returnedVehicle = allVehicles.FirstOrDefault(v => v.RegNo == returnVehicle.RegNo);
        returnedVehicle.VehicleStatus = CarRentalVG.Common.Enums.VehicleStatuses.Available;
        returnedVehicle.Odometer += kmReturned;

        var allBookings = _db.GetBookings();
        var closedBooking = allBookings.FirstOrDefault(b => b.Vehicle.RegNo == returnedVehicle.RegNo);
                
    }

}
