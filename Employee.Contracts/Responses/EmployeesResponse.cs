namespace Contracts.Responses
{
    public class EmployeesResponse
    {
        public IEnumerable<EmployeeResponse> Items { get; init; } = [];
    }
}
