using Microsoft.AspNetCore.Http;

namespace TARge25Shop.Models.Kindergarten
{
    public class KindergartenCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; } = string.Empty;

        public string TeacherName { get; set; } = string.Empty;

        // Lisatud puuduv using ja turvaline algväärtustamine
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

        public List<KindergartenImageViewModel> Image { get; set; }
                    = new List<KindergartenImageViewModel>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}