using TARge25Shop.Core.Dto;

namespace TARge25Shop.Models.Kindergarten
{
    public class KindergartenDeleteViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; } = string.Empty;

        public int TeacherName { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> FileToApiDtos { get; set; }
            = new List<FileToApiDto>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
