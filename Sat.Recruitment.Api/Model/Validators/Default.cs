namespace Sat.Recruitment.Api.Model.Validators
{
    internal static class Default
    {
        public static IValidationRule Create() => new CompositeValidationRule
        {
            new StringNotNullValidationRule(x => x.Name, "The name is required"),
            new StringNotNullValidationRule(x => x.Email, "The email is required"),
            new StringNotNullValidationRule(x => x.Address, "The address is required"),
            new StringNotNullValidationRule(x => x.Phone, "The phone is required")
        };
    }
}
