using System.Collections.Generic;

namespace Sat.Recruitment.Dto.Dtos
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        // Initilize by default just to use .Any() freely
        public List<string> Messages { get; set; } = new List<string>();
    }
}
