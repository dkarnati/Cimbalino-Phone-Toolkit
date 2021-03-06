﻿// ****************************************************************************
// <copyright file="ApplicationManifestBackgroundServiceAgentNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>23-07-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System.Xml;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents a background service agent in the application manifest.
    /// </summary>
    public class ApplicationManifestBackgroundServiceAgentNode
    {
        #region Properties

        /// <summary>
        /// Gets or sets the background service agent specifier.
        /// </summary>
        /// <value>The background service agent specifier.</value>
        public string Specifier { get; set; }

        /// <summary>
        /// Gets or sets the background service agent name.
        /// </summary>
        /// <value>The background service agent name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the background service agent source.
        /// </summary>
        /// <value>The background service agent source.</value>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the background service agent type.
        /// </summary>
        /// <value>The background service agent type.</value>
        public string Type { get; set; }

        #endregion

        internal static ApplicationManifestBackgroundServiceAgentNode ParseXml(XmlReader reader)
        {
            var node = new ApplicationManifestBackgroundServiceAgentNode()
            {
                Specifier = reader.GetAttribute("Specifier"),
                Name = reader.GetAttribute("Name"),
                Source = reader.GetAttribute("Source"),
                Type = reader.GetAttribute("Type")
            };

            reader.Skip();

            return node;
        }
    }
}