// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using FluentAssertions.Equivalency;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.AspNetCore.Extensions;
using Microsoft.Azure.CosmosRepository.Options;
using Microsoft.Azure.CosmosRepository.Providers;
using Microsoft.Azure.CosmosRepositoryAcceptanceTests.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.CosmosRepositoryAcceptanceTests;

[Collection("CosmosTest")]
public abstract class CosmosRepositoryInMemoryAcceptanceTest : CosmosRepositoryAcceptanceTest
{
    protected CosmosRepositoryInMemoryAcceptanceTest(ITestOutputHelper testOutputHelper, Action<RepositoryOptions>? builderOptions = null)
        : base(testOutputHelper, builderOptions, AddInMemoryCosmos)
    {

    }

    private static void AddInMemoryCosmos(IServiceCollection serviceCollection)
    {
        serviceCollection.RemoveCosmosRepositories();
        serviceCollection.AddInMemoryCosmosRepository();
    }
}