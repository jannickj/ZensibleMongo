namespace ZensibleMongo.Update
{
    using Interfaces;

    /// <summary>
    /// Recipe for setting a field on a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    /// <typeparam name="TField"></typeparam>
    internal class SetUpdateSingleRecipe<TDocument, TField> : SetUpdateMultiRecipe<TDocument, TField>, IUpdateSingleRecipe<TDocument>
    {
    }
}