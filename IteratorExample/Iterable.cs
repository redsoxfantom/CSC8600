using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    public interface Iterable<T>
    {
        /// <summary>
        /// Returns the first element in the collection
        /// </summary>
        /// <returns>The first element</returns>
        T GetFirst();

        /// <summary>
        /// Moves the iteration to the next element in the collection
        /// </summary>
        void Advance();

        /// <summary>
        /// Returns the element in the collection the Iterator is currently pointing at
        /// </summary>
        /// <returns>The current element</returns>
        T GetCurrent();

        /// <summary>
        /// Checks if the Iteration is at the end of the collection
        /// </summary>
        /// <returns>True if GetCurrent() would go past the bounds of the backing collection</returns>
        bool AtEnd();

        /// <summary>
        /// Returns the iteration to the starting element
        /// </summary>
        Reset();
    }
}
