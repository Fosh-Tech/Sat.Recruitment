namespace Sat.Recruitment.Domain;

public class NotDuplicateUserSpecification : ISpecification<User>
{
    const string ErrorMessage = "The user is duplicated";
    private readonly List<User> _users;
    public NotDuplicateUserSpecification(IEnumerable<User> existingUsers)
    {
        _users = new List<User>();
        _users.AddRange(existingUsers);
    }
    public bool IsSatisfiedBy(User candidate, Notification notification)
    {
        foreach (var user in _users)
        {
            if (user.Email == candidate.Email ||
                user.Phone == candidate.Phone ||
                user.Name == candidate.Name && user.Address == candidate.Address)
            {
                notification.AddError(ErrorMessage);
                return false;
            }
        }
        return true;
    }
}