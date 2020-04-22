namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;

    public class RoomController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IDeletableEntityRepository<Room> repository;
        private readonly IUsersService usersService;
        private readonly IDeletableEntityRepository<Picture> picturesRepository;

        public RoomController(
            IRoomsService roomsService,
            IDeletableEntityRepository<Room> repository,
            IUsersService usersService,
            IDeletableEntityRepository<Picture> picturesRepository)
        {
            this.roomsService = roomsService;
            this.repository = repository;
            this.usersService = usersService;
            this.picturesRepository = picturesRepository;
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
        [Route("Room/Details/{roomId}")]
        public async Task<IActionResult> Details([FromRoute]string roomId)
        {
            var room = await this.roomsService.GetRoomAsync<RoomDetailsViewModel>(roomId);

            return this.View(room);
        }

        [Authorize]
        [HttpGet]
        [Route("Room/Reserve/{roomId}")]
        public async Task<IActionResult> Reserve([FromRoute]string roomId)
        {
            var inputModel = new ReserveRoomInputModel();

            var pictures = await this.picturesRepository.All().Where(x => x.RoomId == roomId).ToListAsync();

            inputModel.Pictures = pictures.Select(x => x.Url).ToList();
            inputModel.PhoneNumber = await this.usersService.GetUserPhoneNumberAsync(this.User);
            inputModel.CheckIn = DateTime.Now;
            inputModel.CheckOut = DateTime.Now;

            return this.View(inputModel);
        }

        [HttpPost]
        [Route("Room/Reserve/{roomId}")]
        public async Task<IActionResult> Reserve([FromRoute]string roomId, ReserveRoomInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = await this.usersService.GetUserIdAsync(this.User);

            input.UserId = userId;
            input.RoomId = roomId;

            await this.roomsService.ReserveRoom(input);

            this.TempData["InfoMessage"] = "You successfully booked a room!";

            return this.Redirect("/Room/Reservations");
        }

        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            var userId = await this.usersService.GetUserIdAsync(this.User);

            var reservations = await this.roomsService
                .GetAllReservationsAsync<ReservationsAllViewModel>(userId);

            var reservationView = new ReservationViewModel()
            {
                AllReservations = reservations,
            };

            return this.View(reservationView);
        }
    }
}
