﻿namespace ParadiseGuestHouse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.ViewModels.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;
    using System.Threading.Tasks;

    public class RoomController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IDeletableEntityRepository<Room> repository;

        public RoomController(IRoomsService roomsService, IDeletableEntityRepository<Room> repository)
        {
            this.roomsService = roomsService;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var rooms = await this.roomsService
                .GetAllRoomsAsync<RoomsAllViewModel>();

            var roomView = new RoomViewModel()
            {
                AllRooms = rooms,
            };

            return this.View(roomView);
        }

        [HttpGet]
        [Route("Room/RoomDetails/{roomId}")]
        public async Task<IActionResult> RoomDetails([FromRoute]string roomId)
        {
            var room = await this.roomsService.GetRoomAsync<RoomDetailsViewModel>(roomId);

            return this.View(room);
        }

        [HttpGet]
        [Route("Room/Reserve/{roomId}")]
        public async Task<IActionResult> Reserve([FromRoute]string roomId)
        {
            var reserveRoom = await this.roomsService.GetRoomAsync<RoomDetailsViewModel>(roomId);

            return this.View();
        }

        [HttpPost]
        public IActionResult Reserve(ReserveRoomInputModel input)
        {
            return this.Json(input);
        }
    }
}
