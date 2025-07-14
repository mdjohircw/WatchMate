namespace WatchMate_API.DTO.Customer
{
    public class CustomerInfoCreateDTO
    {
        public string? FullName { get; set; }
        public string? CustmerImage { get; set; }
        public string? EmailOrPhone { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? NIDOrPassportNumber { get; set; }
        public string? UserPassword { get; set; }
        public string? UserName { get; set; }
    }
}
