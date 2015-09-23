using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZensibleMongo.Interfaces
{
    /// <summary>
    /// Filter for selecting multiple documents
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IFilterMultiRecipe<TDocument> : IFilterRecipe<TDocument>
    {
    }
}
