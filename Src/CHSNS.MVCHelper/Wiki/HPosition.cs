namespace CHSNS.Wiki
{
    /// <summary>
    /// Represents a Header.
    /// </summary>
    public class HPosition {
        /// <summary>
        /// Initializes a new instance of the <b>HPosition</b> class.
        /// </summary>
        /// <param name="index">The Index.</param>
        /// <param name="text">The Text.</param>
        /// <param name="level">The Header level.</param>
        /// <param name="id">The Unique ID of the Header (0-based counter).</param>
        public HPosition(int index, string text, int level, int id) {
            this.Index = index;
            this.Text = text;
            this.Level = level;
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the Level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the ID (0-based counter).
        /// </summary>
        public int Id { get; set; }
    }
}