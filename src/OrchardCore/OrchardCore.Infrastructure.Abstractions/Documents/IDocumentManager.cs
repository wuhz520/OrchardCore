using System;
using System.Threading.Tasks;
using OrchardCore.Data.Documents;

namespace OrchardCore.Documents
{
    /// <summary>
    /// A generic service to keep in sync any <see cref="IDocument"/> between a document store and a shared cache.
    /// </summary>
    public interface IDocumentManager<TDocument> where TDocument : class, IDocument, new()
    {
        /// <summary>
        /// Loads a single document (or create a new one) for updating and that should not be cached.
        /// </summary>
        Task<TDocument> GetMutableAsync(Func<TDocument> factory = null);

        /// <summary>
        /// Gets a single document (or create a new one) for sharing and that should not be updated.
        /// </summary>
        Task<TDocument> GetImmutableAsync(Func<TDocument> factory = null);

        /// <summary>
        /// Updates the store with the provided document and then updates the cache.
        /// </summary>
        Task UpdateAsync(TDocument document);
    }
}
