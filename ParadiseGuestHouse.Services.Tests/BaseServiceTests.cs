using NUnit.Framework;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ParadiseGuestHouse.Services.Tests
{
    [TestFixture]
    public abstract class BaseServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.RegisterMappings();
        }


        private void RegisterMappings()
        {
            AutoMapperConfig.RegisterMappings(typeof(RoomsAllViewModel).GetTypeInfo().Assembly,
                typeof(RoomViewModel).GetTypeInfo().Assembly);
        }
    }
}
