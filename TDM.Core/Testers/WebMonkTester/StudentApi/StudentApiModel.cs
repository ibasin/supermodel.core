using System.ComponentModel.DataAnnotations;

namespace WebMonkTester.StudentApi;

public class StudentApiModel
{
    [Required] public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public double GPA { get; set; }
}