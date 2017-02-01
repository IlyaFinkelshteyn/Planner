namespace Planner.Models.EventsViewModels.Interfaces
{
    public interface ICreateViewModel<TModel>
    {
        TModel ToItem();
    }

    public interface IUpdateViewModel<TModel>
    {
        int Id { get; set; }

        void UpdateItem(TModel item);
    }
}