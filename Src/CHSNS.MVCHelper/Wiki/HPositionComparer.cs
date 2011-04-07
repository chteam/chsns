namespace CHSNS.Wiki
{
    using System.Collections.Generic;

    /// <summary>
    /// Compares HPosition objects.
    /// </summary>
    public class HPositionComparer : IComparer<HPosition> {

        /// <summary>
        /// Performs the comparison.
        /// </summary>
        /// <param name="x">The first object.</param>
        /// <param name="y">The second object.</param>
        /// <returns>The comparison result.</returns>
        public int Compare(HPosition x, HPosition y) {
            return x.Index.CompareTo(y.Index);
        }
    }
}