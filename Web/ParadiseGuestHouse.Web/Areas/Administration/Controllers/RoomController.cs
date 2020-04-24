namespace ParadiseGuestHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.Room;

    public class RoomController : Controller
    {
        private readonly IRoomsService roomsService;

        public RoomController(IRoomsService roomsService)
        {
            this.roomsService = roomsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRoomInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.roomsService.CreateRoomAsync(input);

            this.TempData["InfoMessage"] = "Room created successfuly!";

            return this.RedirectToAction("All");
        }

        [Authorize]
        public async Task<IActionResult> DeleteRoom(string roomId)
        {
            var result = await this.roomsService.DeleteRoom(roomId);

            if (result == true)
            {
                this.TempData["InfoMessage"] = "Room deleted successfuly!";
                return this.RedirectToAction("All");
            }

            return this.NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("Room/Edit/{roomId}")]
        public async Task<IActionResult> Edit([FromRoute]string roomId)
        {
            var result = await this.roomsService.GetRoomForEditAsync(roomId);

            return this.View(result);
        }

        [HttpPost]
        [Authorize]
        [Route("Room/Edit/{roomId}")]
        public async Task<IActionResult> Edit([FromRoute]string roomId, EditRoomViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.roomsService.EditRoomAsync(roomId, input);
            this.TempData["InfoMessage"] = "Room edited successfuly!";
            return this.RedirectToAction("All");
        }
    }
}
