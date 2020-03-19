namespace ParadiseGuestHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Room;

    public class RoomController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IDeletableEntityRepository<Room> repository;

        public RoomController(IRoomsService roomsService, IDeletableEntityRepository<Room> repository)
        {
            this.roomsService = roomsService;
            this.repository = repository;
        }

        public IActionResult CreateRoom()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.roomsService.CreateRoom(input.RoomType, input.Price, input.NumberOfBeds, input.HasBathroom, input.HasRoomService, input.HasSeaView, input.HasMountainView, input.HasWifi, input.HasTv, input.HasPhone, input.HasAirConditioner, input.HasHeater);

            return this.Redirect("/Room/All");
        }

        public async Task<IActionResult> DeleteRoom(string roomId)
        {
            var result = await this.roomsService.DeleteRoom(roomId);

            if (result == true)
            {
                return this.Redirect("/Room/All");
            }

            return this.NotFound();
        }
    }
}
