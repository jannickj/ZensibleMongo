namespace ZensibleMongo.Update
{
    using Interfaces;

    /// <summary>
    /// Recipe for setting a field on a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    /// <typeparam name="TField"></typeparam>
    public class SetSingleRecipe<TDocument, TField> : SetRecipe<TDocument, TField>, IUpdateSingleDefinition<TDocument>
    {
    }
}