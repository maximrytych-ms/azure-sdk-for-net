// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(PeeringOption))
            {
                writer.WritePropertyName("peeringOption"u8);
                writer.WriteStringValue(PeeringOption.Value.ToString());
            }
            writer.WritePropertyName("optionBProperties"u8);
            writer.WriteObjectValue(OptionBProperties);
            if (Optional.IsDefined(OptionAProperties))
            {
                writer.WritePropertyName("optionAProperties"u8);
                writer.WriteObjectValue(OptionAProperties);
            }
            writer.WriteEndObject();
        }

        internal static NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration DeserializeNetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<EnabledDisabledState> administrativeState = default;
            Optional<string> networkToNetworkInterconnectId = default;
            Optional<PeeringOption> peeringOption = default;
            NetworkFabricOptionBProperties optionBProperties = default;
            Optional<NetworkFabricOptionAProperties> optionAProperties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("administrativeState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    administrativeState = new EnabledDisabledState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("networkToNetworkInterconnectId"u8))
                {
                    networkToNetworkInterconnectId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("peeringOption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    peeringOption = new PeeringOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionBProperties"u8))
                {
                    optionBProperties = NetworkFabricOptionBProperties.DeserializeNetworkFabricOptionBProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("optionAProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionAProperties = NetworkFabricOptionAProperties.DeserializeNetworkFabricOptionAProperties(property.Value);
                    continue;
                }
            }
            return new NetworkFabricPropertiesManagementNetworkConfigurationInfrastructureVpnConfiguration(Optional.ToNullable(administrativeState), networkToNetworkInterconnectId.Value, Optional.ToNullable(peeringOption), optionBProperties, optionAProperties.Value);
        }
    }
}
