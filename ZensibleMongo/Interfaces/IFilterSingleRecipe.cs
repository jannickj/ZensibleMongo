using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZensibleMongo.Interfaces
{
    /// <summary>
    /// A filter to select a single document
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public interface IFilterSingleRecipe<TDocument> : IFilterRecipe<TDocument>
    {
    }
}
