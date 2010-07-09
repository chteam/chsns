//-----------------------------------------------------------------------
// <copyright file="BytesExtension.cs" company="eice.com.cn">
//     Copyright (c) CHSNS eice.com.cn. All rights reserved.
// </copyright>
// <author>chsword</author>
//-----------------------------------------------------------------------

namespace CHSNS
{
    using System.Text;

    /// <summary>
    /// A extension method to convert byte[] to string
    /// </summary>
    internal static class BytesExtension
    {
        /// <summary>
        /// Toes the hex upper string.
        /// </summary>
        /// <param name="data">The data you will tf.</param>
        /// <returns>The hex upper letter string.</returns>
        internal static string ToHexUpperString(this byte[] data)
        {
            var codes = new StringBuilder();
            for (var i = 0; i < data.Length; ++i)
            {
                codes.Append(data[i].ToString("x2"));
            }

            return codes.ToString().ToUpper();
        }

        /// <summary>
        /// Toes the hex lower string.
        /// </summary>
        /// <param name="data">The data you will tf.</param>
        /// <returns>The hex lower letter string.</returns>
        internal static string ToHexLowerString(this byte[] data)
        {
            var codes = new StringBuilder();
            for (var i = 0; i < data.Length; ++i)
            {
                codes.Append(data[i].ToString("x2"));
            }

            return codes.ToString().ToLower();
        }
    }
}