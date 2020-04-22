using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.InputModels.Room;
using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ParadiseGuestHouse.Services.Tests
{
    public class MapperFixture
    {
        public MapperFixture()
        {
            AutoMapperConfig.RegisterMappings(typeof(RoomsAllViewModel).GetTypeInfo().Assembly, typeof(CreateRoomInputModel).GetTypeInfo().Assembly);
        }
    }
}
