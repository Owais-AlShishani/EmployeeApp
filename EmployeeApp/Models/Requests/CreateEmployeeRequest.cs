namespace EmployeeApp.Models.Requests
{
    public class CreateEmployeeRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? Email { get; init; }
        public required string Phone { get; init; }
        public string? Address { get; init; }
        public required Guid CreatedById { get; init; }
        public required decimal Salary { get; init; }
    }
}
