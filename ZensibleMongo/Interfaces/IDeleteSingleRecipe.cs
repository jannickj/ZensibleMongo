namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for recipes that delete single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IDeleteSingleRecipe<TDocument> : IDeleteRecipe<TDocument>
    {
    }
}