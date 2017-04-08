//-----------------------------------------------------------------------
// <copyright file="City.cs" company="eice.com.cn">
//     Copyright (c) CHSNS eice.com.cn. All rights reserved.
// </copyright>
// <author>chsword</author>
//-----------------------------------------------------------------------

namespace CHSNS.Models
{
    /// <summary>
    /// 城市类，描述城市 信息
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the P id.
        /// </summary>
        public int ParentId { get; set; }
    }
}