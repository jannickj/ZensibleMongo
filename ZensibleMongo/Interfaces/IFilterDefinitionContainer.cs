namespace ZensibleMongo.Interfaces
{
    /// <summary>
    /// Interface for recipes that contain filters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilterDefinitionContainer<T>
    {
        /// <summary>
        /// Filter
        /// </summary>
        IFilterDefinition<T> FilterDefinition { get; }
    }
}