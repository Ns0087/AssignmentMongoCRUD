namespace AssignmentMongoCRUD.Models.RequestViewModel
{
    public class EmployeeRequestModel
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Department { get; set; }
        public string? Salary { get; set; }
    }
}
