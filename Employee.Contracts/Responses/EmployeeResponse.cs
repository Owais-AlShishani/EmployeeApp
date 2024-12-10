namespace Contracts.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
