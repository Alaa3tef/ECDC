using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class EvaluationCriteriaDTO
    {
        public int Id { get; set; }

        public int RatingId { get; set; }

        public string Comment { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
