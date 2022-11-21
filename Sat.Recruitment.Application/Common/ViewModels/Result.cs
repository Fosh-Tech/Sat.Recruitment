using System.Collections.Generic;

namespace Sat.Recruitment.Application.Common.ViewModels
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}