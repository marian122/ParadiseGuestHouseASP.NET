using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
    [CollectionDefinition(nameof(MapperFixture))]
    public class MapperFixtureCollection : ICollectionFixture<MapperFixture>
    {
    }
}
