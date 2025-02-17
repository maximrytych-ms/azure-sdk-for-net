// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A Class representing a RackSku along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="RackSkuResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetRackSkuResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetRackSku method.
    /// </summary>
    public partial class RackSkuResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="RackSkuResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string rackSkuName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/rackSkus/{rackSkuName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _rackSkuClientDiagnostics;
        private readonly RackSkusRestOperations _rackSkuRestClient;
        private readonly RackSkuData _data;

        /// <summary> Initializes a new instance of the <see cref="RackSkuResource"/> class for mocking. </summary>
        protected RackSkuResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "RackSkuResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal RackSkuResource(ArmClient client, RackSkuData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="RackSkuResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal RackSkuResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _rackSkuClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetworkCloud", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string rackSkuApiVersion);
            _rackSkuRestClient = new RackSkusRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, rackSkuApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.NetworkCloud/rackSkus";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual RackSkuData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get the properties of the provided rack SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/rackSkus/{rackSkuName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RackSkus_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RackSkuResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _rackSkuClientDiagnostics.CreateScope("RackSkuResource.Get");
            scope.Start();
            try
            {
                var response = await _rackSkuRestClient.GetAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RackSkuResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the properties of the provided rack SKU.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetworkCloud/rackSkus/{rackSkuName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RackSkus_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RackSkuResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _rackSkuClientDiagnostics.CreateScope("RackSkuResource.Get");
            scope.Start();
            try
            {
                var response = _rackSkuRestClient.Get(Id.SubscriptionId, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RackSkuResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
