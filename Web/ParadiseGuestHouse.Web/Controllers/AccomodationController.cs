namespace ParadiseGuestHouse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels;
    using System.Threading.Tasks;

    public class AccomodationController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IDeletableEntityRepository<Room> repository;

        public AccomodationController(IRoomsService roomsService, IDeletableEntityRepository<Room> repository)
        {
            this.roomsService = roomsService;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult SingleRoom()
        {
            return this.View();
        }

        public IActionResult Reserve()
        {
            return this.View();
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

            await this.roomsService.CreateRoom(input.RoomType, input.Price, input.NumberOfBeds, input.HasBathroom, input.HasRoomService, input.HasSeaView,input.HasMountainView, input.HasWifi, input.HasTv, input.HasPhone, input.HasAirConditioner, input.HasHeater);

            return this.Redirect("/");
        }
    }
}
