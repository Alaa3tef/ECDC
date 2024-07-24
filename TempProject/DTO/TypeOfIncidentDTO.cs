using System.ComponentModel;

namespace TempProject.DTO
{
    public class TypeOfIncidentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
