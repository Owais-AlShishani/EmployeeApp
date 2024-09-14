namespace EmployeeApp.Models.Requests
{
    public class UpdateEmployeeRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? Email { get; init; }
        public required string Phone { get; init; }
        public required decimal Salary { get; init; }
        public bool IsDeleted { get; init; }
    }
}
