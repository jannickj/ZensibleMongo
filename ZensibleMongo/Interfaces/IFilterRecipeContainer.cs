namespace ZensibleMongo.Interfaces
{
    /// <summary>
    /// Interface for recipes that contain filters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilterRecipeContainer<T>
    {
        /// <summary>
        /// Filter
        /// </summary>
        IFilterRecipe<T> FilterRecipe { get; }
    }
}