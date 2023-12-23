using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
    public class CustomerReportDTO
    {
        public int Id { get; set; }
        public int RigId { get; set; }
        public int RigNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }
        public string ClientRepresentative { get; set; }
        public string Client { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int EvaluationResult { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public string CustomerRepresentative { get; set; }
        public string ECDCRepresentative { get; set; }
        //public int RatingId { get; set; }
        //public string RatingName { get; set; }
        public string? CommentEvaluationCriteria { get; set; }
        public string? CommentEvaluationCriteria1 { get; set; }
        public string? CommentEvaluationCriteria2 { get; set; }
        public string? CommentEvaluationCriteria3 { get; set; }
        public string? CommentEvaluationCriteria4 { get; set; }
        public string? CommentEvaluationCriteria5 { get; set; }
        public string? CommentEvaluationCriteria6 { get; set; }
        public string? CommentEvaluationCriteria7 { get; set; }

        public string Rating { get; set; }
        public string Rating1 { get; set; }
        public string Rating2 { get; set; }
        public string Rating3 { get; set; }
        public string Rating4 { get; set; }
        public string Rating5 { get; set; }
        public string Rating6 { get; set; }
        public string Rating7 { get; set; }
        public string userID { get; set; }

        [DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
