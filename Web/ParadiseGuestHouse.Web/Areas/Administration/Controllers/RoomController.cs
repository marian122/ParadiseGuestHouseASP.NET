namespace ParadiseGuestHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.Room;

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

            await this.roomsService.CreateRoom(input);

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

        [HttpGet]
        [Route("Room/Edit/{roomId}")]
        public async Task<IActionResult> Edit([FromRoute]string roomId)
        {
            var result = await this.roomsService.GetRoomForEditAsync(roomId);

            return this.View(result);
        }

        [HttpPost]
        [Route("Room/Edit/{roomId}")]
        public async Task<IActionResult> Edit([FromRoute]string roomId, EditRoomViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.roomsService.EditRoomAsync(roomId, input);

            return this.Redirect("/Room/All");
        }
    }
}
