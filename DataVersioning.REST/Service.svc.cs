/// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Linq;
using System.Net;
using Microsoft.ServiceModel.Web;
using Microsoft.ServiceModel.Web.SpecializedServices;

// The following line sets the default namespace for DataContract serialized typed to be ""
[assembly: ContractNamespace("", ClrNamespace = "DataVersioning.REST")]

namespace DataVersioning.REST
{
  // TODO: Modify the service behavior settings (instancing, concurrency etc) based on the service's requirements. Use ConcurrencyMode.Multiple if your service implementation
  //       is thread-safe.
  // TODO: Please set IncludeExceptionDetailInFaults to false in production environments
  [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  public class Service : SingletonServiceBase<SampleItem>, ISingletonService<SampleItem>
  {
    // TODO: This variable used by the sample implementation. Remove if needed
    SampleItem item = new SampleItem() { Value = "SampleValue" };

    /// <summary>
    /// This method is invoked for HTTP GET requests.
    /// A null return value will result in a response status code of NotFound (404), unless the method explicitly sets the status code to a different error.
    /// </summary>
    /// <returns>The resource if it exists, null otherwise.</returns>
    protected override SampleItem OnGetItem()
    {
      // TODO: Change the sample implementation here
      return this.item;
    }

    /// <summary>
    /// This method is invoked for HTTP POST requests.
    /// If the resource does not exist, create the resource and set wasResourceCreated to true.
    /// If the resource already exists, then the semantics of the Post call is application-specific.
    /// A null return value will result in a response status code of Conflict (409), unless the method explicitly sets the status code to a different error
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="wasResourceCreated"></param>
    /// <returns>The item that was Posted. Returns null if the Post could not be processed due to the current state of the resource.</returns>
    protected override SampleItem OnAddItem(SampleItem newValue, out bool wasResourceCreated)
    {
      // TODO: Change the sample implementation here
      if (this.item == null)
      {
        this.item = newValue;
        wasResourceCreated = true;
        return this.item;
      }
      else
      {
        throw new WebProtocolException(HttpStatusCode.Conflict);
      }
    }

    /// <summary>
    /// This method is invoked for HTTP PUT requests. This method should be idempotent.
    /// If the resource does not exist, create the resource and set wasResourceCreated to true.
    /// If the resource already exists, update the resource to the new value.
    /// A null return value will result in a response status code of InternalServerError (500), unless the method explicitly sets the status code to a different error
    /// </summary>
    /// <param name="newValue">The new item to be created, or to replace the old item.</param>
    /// <param name="wasResourceCreated">Indicates if the item was created.</param>
    /// <returns>The new item created or used to replace. Returns null in case of an error.</returns>
    protected override SampleItem OnUpdateItem(SampleItem newValue, out bool wasResourceCreated)
    {
      // TODO: Change the sample implementation here
      wasResourceCreated = (this.item == null);
      this.item = newValue;
      return this.item;
    }

    /// <summary>
    /// This method is called for HTTP DELETE requests
    /// Delete the resource, if it exists. If the resource does not exist return false. 
    /// A return value of false will result in a response status code of NotFound (404), unless the method explicitly sets the status code to a different error 
    /// </summary>
    /// <returns>False if delete failed, true if successful.</returns>
    protected override bool OnDeleteItem()
    {
      // TODO: Change the sample implementation here
      bool canItemBeDeleted = (this.item != null);
      this.item = null;
      return canItemBeDeleted;
    }

  }

  // TODO: Modify the SampleItem. Use Visual Studio refactoring while modifying so that the references are updated.
  /// <summary>
  /// Sample type for the singleton resource. 
  /// By default all public properties are DataContract serializable
  /// </summary>
  public class SampleItem
  {
    public string Value { get; set; }
  }
}