namespace Planner.Models.EventsModel.Interfaces
{
    public interface IDetailable<TDetail>
    {
        TDetail ToDetail();
    }
}