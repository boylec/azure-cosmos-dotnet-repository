// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.


// ReSharper disable once CheckNamespace
namespace Microsoft.Azure.CosmosRepository;

internal partial class InMemoryRepository<TItem>
{
    public async ValueTask<TResult> QueryAsync<TResult>(
        ISpecification<TItem, TResult> specification,
        CancellationToken cancellationToken = default)
        where TResult : IQueryResult<TItem>
    {
        await Task.CompletedTask;

        if (specification.UseContinuationToken)
        {
            throw new NotImplementedException();
        }

        IQueryable<TItem> query = Items.Values
            .Select(DeserializeItem).AsQueryable()
            .Where(item => item.Type == typeof(TItem).Name);

        query = _specificationEvaluator.GetQuery(query, specification);

        var countResponse = query.Count();

        return _specificationEvaluator.GetResult(
            query.ToList().AsReadOnly(),
            specification,
            countResponse,
            0,
            "");
    }
}