﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Dynamic
{
    internal class DynamicDataOptions
    {
        public DynamicDataOptions()
        {
            // Set the default
            DateTimeFormat = DynamicData.RoundTripFormat;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="options"></param>
        public DynamicDataOptions(DynamicDataOptions options)
        {
            PropertyNameFormat = options.PropertyNameFormat;
            DateTimeFormat = options.DateTimeFormat;
        }

        public PropertyNameFormat PropertyNameFormat { get; set; }

        public string DateTimeFormat { get; set; }

        internal static JsonSerializerOptions ToSerializerOptions(DynamicDataOptions options)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                Converters =
                {
                    new DynamicData.DynamicTimeSpanConverter(),
                    new DynamicData.DynamicDateTimeConverter(options.DateTimeFormat),
                    new DynamicData.DynamicDateTimeOffsetConverter(options.DateTimeFormat),
                }
            };

            switch (options.PropertyNameFormat)
            {
                case PropertyNameFormat.CamelCase:
                    serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    break;
                case PropertyNameFormat.None:
                default:
                    break;
            }

            return serializerOptions;
        }

        internal static DynamicDataOptions FromSerializerOptions(JsonSerializerOptions options)
        {
            DynamicDataOptions value = new();

            JsonConverter? c = options.Converters.FirstOrDefault(c => c is DynamicData.DynamicDateTimeConverter);
            if (c is DynamicData.DynamicDateTimeConverter dtc)
            {
                value.DateTimeFormat = dtc.Format;
            }

            if (options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase)
            {
                value.PropertyNameFormat = PropertyNameFormat.CamelCase;
            }

            return value;
        }
    }
}
