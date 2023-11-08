namespace WebApplication1.DTO
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? Age { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public DateOnly? Birthday { get; set; }
    }

}
