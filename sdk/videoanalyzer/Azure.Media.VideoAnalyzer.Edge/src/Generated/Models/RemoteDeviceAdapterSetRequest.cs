// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary> Creates a new remote device adapter or updates an existing one. </summary>
    public partial class RemoteDeviceAdapterSetRequest : MethodRequest
    {
        /// <summary> Initializes a new instance of RemoteDeviceAdapterSetRequest. </summary>
        /// <param name="remoteDeviceAdapter"> The Video Analyzer edge module can act as a transparent gateway for video, enabling IoT devices to send video to the cloud from behind a firewall. A remote device adapter should be created for each such IoT device. Communication between the cloud and IoT device would then flow via the Video Analyzer edge module. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="remoteDeviceAdapter"/> is null. </exception>
        public RemoteDeviceAdapterSetRequest(RemoteDeviceAdapter remoteDeviceAdapter)
        {
            Argument.AssertNotNull(remoteDeviceAdapter, nameof(remoteDeviceAdapter));

            RemoteDeviceAdapter = remoteDeviceAdapter;
            MethodName = "remoteDeviceAdapterSet";
        }

        /// <summary> Initializes a new instance of RemoteDeviceAdapterSetRequest. </summary>
        /// <param name="methodName"> Direct method method name. </param>
        /// <param name="apiVersion"> Video Analyzer API version. </param>
        /// <param name="remoteDeviceAdapter"> The Video Analyzer edge module can act as a transparent gateway for video, enabling IoT devices to send video to the cloud from behind a firewall. A remote device adapter should be created for each such IoT device. Communication between the cloud and IoT device would then flow via the Video Analyzer edge module. </param>
        internal RemoteDeviceAdapterSetRequest(string methodName, string apiVersion, RemoteDeviceAdapter remoteDeviceAdapter) : base(methodName, apiVersion)
        {
            RemoteDeviceAdapter = remoteDeviceAdapter;
            MethodName = methodName ?? "remoteDeviceAdapterSet";
        }

        /// <summary> The Video Analyzer edge module can act as a transparent gateway for video, enabling IoT devices to send video to the cloud from behind a firewall. A remote device adapter should be created for each such IoT device. Communication between the cloud and IoT device would then flow via the Video Analyzer edge module. </summary>
        public RemoteDeviceAdapter RemoteDeviceAdapter { get; set; }
    }
}
