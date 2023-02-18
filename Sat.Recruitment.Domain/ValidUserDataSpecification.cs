using System.Text;

namespace Sat.Recruitment.Domain;

public class ValidUserDataSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User candidate, Notification notification)
    {
        var n = notification.GetErrors().Length;
        //Validate if Name is null
        if (string.IsNullOrWhiteSpace(candidate.Name))
            notification.AddError("The name is required.");
        
        //Validate if Email is null
        if (string.IsNullOrWhiteSpace(candidate.Email))
            notification.AddError("The email is required.");
        
        //Validate if Address is null
        if (string.IsNullOrWhiteSpace(candidate.Address))
            notification.AddError("The address is required.");
        
        //Validate if Phone is null
        if (string.IsNullOrEmpty(candidate.Phone))
            notification.AddError("The phone is required.");
        
        return notification.GetErrors().Length == n;
    }
}