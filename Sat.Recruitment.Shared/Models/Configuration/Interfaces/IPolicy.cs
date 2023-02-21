namespace Sat.Recruitment.Shared.Models.Configuration.Interfaces
{
    public interface IPolicy
    {
        string[] ExposedHeaders { get; set; }
        string[] Headers { get; set; }
        string[] Methods { get; set; }
        string Name { get; set; }
        string[] Origins { get; set; }
    }
}
