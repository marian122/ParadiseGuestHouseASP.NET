namespace ParadiseGuestHouse.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "ParadiseGuestHouse";

        public const string SystemEmail = "paradiseguesthouse@abv.bg";

        public const string AdministratorRoleName = "Administrator";

        public const string UserRoleName = "User";

        public const string InvalidEmail = "Невалиден имейл адрес";

        public const string RequiredField = "Полето е задължително";

        public const string InvalidPhoneNumber = "Невалиден телефонен номер";

        public const string CountOfPeopleInRoomLength = "Полето трябва да е между 1 и 10.";

        public const string NumberOfBedsRange = "Броят на леглата трябва да е между 1 и 10";

        public const string ConfHallReserveGuestsMax = "Полето трябва де бъде между 1 и 100";

        public const string UserNameMaxLength = "Полето може да съдържа най-много 20 символа";

        public const string RestaurantReserveGuestsMax = "Полето трябва де бъде между 1 и 100";

        public const string ContentMessageMaxLength = "Полето може да съдържа най-мно 300 символа";

        public const string ContactFormTitleMaxLength = "Полето може да съдържа най-много 30 символа";

        public const string CheckDateTimeAttribute = "Моля въведете дата след днес!";

        public const string InvalidOperationExceptionForRestaurantGetAllReservations = "Exception happened in RestaurantService while getting all reservations for current user from IDeletableEntityRepository<RestaurantReservations>";

        public const string InvalidOperationExceptionForRestaurantGetAllReservationsForAdmin = "Exception happened in RestaurantService while getting all reservations for admin from IDeletableEntityRepository<RestaurantReservations>";

        public const string InvalidOperationExceptionForRestaurantReservation = "Exception happened in RestaurantService while saving the Reservation in IDeletableEntityRepository<RestaurantReservation>";

        public const string InvalidOperationExceptionForConferenceHallGetAllReservations = "Exception happened in ConferenceHallService while getting all reservations for current user from IDeletableEntityRepository<ConferenceHallReservations>";

        public const string InvalidOperationExceptionForConferenceHallGetAllReservationsForAdmin = "Exception happened in ConferenceHallService while getting all reservations for admin IDeletableEntityRepository<ConferenceHallReservations>";

        public const string InvalidOperationExceptionForConferenceHallReservation = "Exception happened in ConferenceHallService while saving the Reservation in IDeletableEntityRepository<ConferenceHallReservation>";

        public const string InvalidOperationExceptionForRoomDelete = "Exception happened in RoomsService while deleting room from IDeletableEntityRepository<Room>";

        public const string InvalidOperationExceptionForRoomEdit = "Exception happened in RoomsService while editing room in IDeletableEntityRepository<Room>";

        public const string InvalidOperationExceptionForRoomGetAllReservations = "Exception happened in RoomsService while getting all reservations for current user from IDeletableEntityRepository<RoomReservations>";

        public const string InvalidOperationExceptionForRoomGetAllReservationsForAdmin = "Exception happened in RoomsService while getting all reservations for admin from IDeletableEntityRepository<RoomReservations>";

        public const string InvalidOperationExceptionForRoomSearchForEdit = "Exception happened in RoomsService search for room in IDeletableEntityRepository<Room>";

        public const string InvalidOperationExceptionForRoomReservation = "Exception happened in RoomsService while saving the Reservation in IDeletableEntityRepository<RoomReservation>";

        public const string InvalidOperationExceptionForRoomCreate = "Exception happened in RoomsService while creating room in IDeletableEntityRepository<Room>";

        public const string InvalidOperationExceptionInPictureService = "Exception happened in PictureService while saving the Picture in IDeletableEntityRepository<Picture>";

        public const string EnterValidNumberOfGuestsError = "Максимален брой гости ";

        public const string EnterAtleastOneNightStandsError = "Моля въведете резервация с поне 1 нощувка!";

        public const string FreeSeatsForHallError = "Свободните места за тази дата и зала са ";

        public const string FreeSeatsForRestaurantError = "Свободните места за тази дата са ";

        public const string ReserveRestaurantTempDataSuccess = "You successfully booked a restaurant!";

        public const string ReserveConferenceHallTempDataSuccess = "You successfully booked a conference hall!";

        public const string ReserveRoomTempDataSuccess = "You successfully booked a room!";

        public const string CreateRoomTempDataSuccess = "Room created successfuly!";

        public const string DeleteRoomTempDataSuccess = "Room deleted successfuly!";

        public const string EditRoomTempDataSuccess = "Room updated successfuly!";

        public const string SuccessfullySentAnEmail = "You have successfully sent an email! Please check your mailbox for a reply!";
    }
}
