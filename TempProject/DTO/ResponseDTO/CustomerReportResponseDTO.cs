using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class CustomerReportResponseDTO
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

        public string Rating { get; set; }
        public string Rating1 { get; set; }
        public string Rating2 { get; set; }
        public string Rating3 { get; set; }
        public string Rating4 { get; set; }
        public string Rating5 { get; set; }
        public string Rating6 { get; set; }
        public string Rating7 { get; set; }
        public string? CommentEvaluationCriteria { get; set; }
        public string? CommentEvaluationCriteria1 { get; set; }
        public string? CommentEvaluationCriteria2 { get; set; }
        public string? CommentEvaluationCriteria3 { get; set; }
        public string? CommentEvaluationCriteria4 { get; set; }
        public string? CommentEvaluationCriteria5 { get; set; }
        public string? CommentEvaluationCriteria6 { get; set; }
        public string? CommentEvaluationCriteria7 { get; set; }

        //public List<EvaluationCriteriaDTO > evaluationCriteriaDTOs  = new List<EvaluationCriteriaDTO >();


        [DefaultValue(false)]
		public bool IsDeleted { get; set; }
		public string userID { get; set; }
		public string userName { get; set; }


        //public void SetRating(int index, List<EvaluationCriteria> evaluationCriterias)
        //{
        //    // Check if there's a rating available for the current index
        //    if (index < evaluationCriterias.Count)
        //    {
        //        switch (index)
        //        {
        //            case 0:
        //                Rating = evaluationCriterias[index].Rating;
        //                break;
        //            case 1:
        //                Rating1 = evaluationCriterias[index].Rating;
        //                break;
        //            case 2:
        //                Rating2 = evaluationCriterias[index].Rating;
        //                break;
        //            case 3:
        //                Rating3 = evaluationCriterias[index].Rating;
        //                break;
        //            case 4:
        //                Rating4 = evaluationCriterias[index].Rating;
        //                break;
        //            case 5:
        //                Rating5 = evaluationCriterias[index].Rating;
        //                break;
        //            case 6:
        //                Rating6 = evaluationCriterias[index].Rating;
        //                break;
        //            case 7:
        //                Rating7 = evaluationCriterias[index].Rating;
        //                break;
        //        }
        //    }
           
        //}

        //public void SetComment(int index, List<EvaluationCriteria> evaluationCriterias)
        //{
        //    // Check if there's a comment available for the current index
        //    if (index < evaluationCriterias.Count)
        //    {
        //        // Assign the corresponding comment
        //        switch (index)
        //        {
        //            case 0:
        //                CommentEvaluationCriteria = string.Empty;
        //                break;
        //            case 1:
        //                CommentEvaluationCriteria1 = string.Empty;
        //                break;
        //            case 2:
        //                CommentEvaluationCriteria2 = string.Empty;
        //                break;
        //            case 3:
        //                CommentEvaluationCriteria3 = string.Empty;
        //                break;
        //            case 4:
        //                CommentEvaluationCriteria4 = string.Empty;
        //                break;
        //            case 5:
        //                CommentEvaluationCriteria5 = string.Empty;
        //                break;                    
        //            case 6:
        //                CommentEvaluationCriteria6 = string.Empty;
        //                break;
        //            case 7:
        //                CommentEvaluationCriteria7 = string.Empty;
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        // If no comment is available, set an empty string
        //        switch (index)
        //        {
        //            case 0:
        //                CommentEvaluationCriteria = string.Empty;
        //                break;
        //            case 1:
        //                CommentEvaluationCriteria1 = string.Empty;
        //                break;
        //            case 2:
        //                CommentEvaluationCriteria2 = string.Empty;
        //                break;
        //            case 3:
        //                CommentEvaluationCriteria3 = string.Empty;
        //                break;
        //            case 4:
        //                CommentEvaluationCriteria4 = string.Empty;
        //                break;
        //            case 5:
        //                CommentEvaluationCriteria5 = string.Empty;
        //                break;
        //            case 6:
        //                CommentEvaluationCriteria6 = string.Empty;
        //                break;
        //            case 7:
        //                CommentEvaluationCriteria7 = string.Empty;
        //                break;
        //        }
        //    }
        //}

    }
}
