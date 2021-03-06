// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ManagedApplicationIdentityDescription" />.
    /// </summary>
    internal class ManagedApplicationIdentityDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ManagedApplicationIdentityDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ManagedApplicationIdentityDescription GetFromJsonProperties(JsonReader reader)
        {
            var tokenServiceEndpoint = default(string);
            var managedIdentities = default(IEnumerable<ManagedApplicationIdentity>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("TokenServiceEndpoint", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    tokenServiceEndpoint = reader.ReadValueAsString();
                }
                else if (string.Compare("ManagedIdentities", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    managedIdentities = reader.ReadList(ManagedApplicationIdentityConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ManagedApplicationIdentityDescription(
                tokenServiceEndpoint: tokenServiceEndpoint,
                managedIdentities: managedIdentities);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ManagedApplicationIdentityDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.TokenServiceEndpoint != null)
            {
                writer.WriteProperty(obj.TokenServiceEndpoint, "TokenServiceEndpoint", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ManagedIdentities != null)
            {
                writer.WriteEnumerableProperty(obj.ManagedIdentities, "ManagedIdentities", ManagedApplicationIdentityConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
