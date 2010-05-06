namespace MvcHelper
{
    /// <summary>
    /// Class that represents settings for a FlexiGrid.
    /// TODO: Needs to re-factor the generic and non-generic version of FlexiGrid setttings class.
    /// </summary>
    public class FlexiGridSettings
    {
        #region Overriden Methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Render();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Renders the grid..
        /// </summary>
        /// <returns>Rendered grid in text fomat.</returns>
        private string Render()
        {
            return string.Empty;
        }

        #endregion
    }
}
