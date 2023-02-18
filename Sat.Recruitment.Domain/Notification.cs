namespace Sat.Recruitment.Domain;

/// <summary>
/// Validate entities by implementing the Specification pattern and the Notification pattern
/// </summary>
/// <remarks>
/// <para>
/// A notification is an object that collects errors, each validation failure
/// adds an error to the notification. A validation method returns a
/// notification, which you can then interrogate to get more information.
/// </para>
/// <para>
/// Replacing Throwing Exceptions with Notification in Validations:
/// <see href="https://martinfowler.com/articles/replaceThrowWithNotification.html"/>
/// </para>
/// </remarks>
public class Notification
{
    private readonly HashSet<string> _errors = new();

    public void AddError(string message) { _errors.Add(message); }
    public string[] GetErrors() => _errors.ToArray();
    public bool HasErrors => _errors.Count > 0;
}
