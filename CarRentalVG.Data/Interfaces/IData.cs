using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using System.Linq.Expressions;

namespace CarRentalVG.Data.Interfaces;

public interface IData
{
    List<T> Get<T>(Expression<Func<T, bool>>? expression);
    T? Single<T>(Expression<Func<T, bool>>? expression);
    Task Add<T>(T item);



    IEnumerable<IPerson> GetCustomer();
    IEnumerable<VehicleInherit> GetVehicles(VehicleStatuses status = default);
    IEnumerable<IBooking> GetBookings();
    public void Add(IPerson inputCustomer);
    public void Add(VehicleInherit inputVehicle);
    public void AddBooking(Booking b);
    int NextPersonID { get; set; }
    int NextVehicleID { get; set; }
}