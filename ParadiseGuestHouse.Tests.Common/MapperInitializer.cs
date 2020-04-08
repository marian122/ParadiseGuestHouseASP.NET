using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ParadiseGuestHouse.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(RoomsService).GetTypeInfo().Assembly,
                typeof(RoomsAllViewModel).GetTypeInfo().Assembly);
        }
    }
}
