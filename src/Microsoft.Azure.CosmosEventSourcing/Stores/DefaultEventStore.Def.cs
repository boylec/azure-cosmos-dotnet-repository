// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.CosmosEventSourcing.Items;
using Microsoft.Azure.CosmosRepository;

namespace Microsoft.Azure.CosmosEventSourcing.Stores;

internal partial class DefaultEventStore<TEventItem> :
    IEventStore<TEventItem> where TEventItem : EventItem
{
    private readonly IBatchRepository<TEventItem> _batchRepository;
    private readonly IReadOnlyRepository<TEventItem> _readOnlyRepository;

    public DefaultEventStore(
        IRepository<TEventItem> repository)
    {
        _batchRepository = repository;
        _readOnlyRepository = repository;
    }
}