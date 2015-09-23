namespace ZensibleMongo.Interfaces
{
    using System.Collections.Immutable;
    using MongoDB.Driver;

    /// <summary>
    /// Inferface for update recipe that only updates a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IUpdateSingleDefinition<TDocument> : ICollectionContainer<TDocument>, IFilterDefinitionContainer<TDocument>
    {
        /// <summary>
        /// All updates to do on the document
        /// </summary>
        /// <returns></returns>
        ImmutableList<UpdateDefinition<TDocument>> UpdateDefinitions();
    }
}