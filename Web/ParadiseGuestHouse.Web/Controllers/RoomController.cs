namespace ParadiseGuestHouse.Web.Controllers
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
        private readonly IUsersService usersService;

        public RoomController(IRoomsService roomsService, IDeletableEntityRepository<Room> repository, IUsersService usersService)
        {
            this.roomsService = roomsService;
            this.repository = repository;
            this.usersService = usersService;
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

            return this.Redirect("/");
        }
    }
}
