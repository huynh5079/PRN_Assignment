using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public partial class NewsArticle
    {
        public int NewsArticleId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string NewsTitle { get; set; } = null!;

        [Required(ErrorMessage = "Headline is required")]
        [StringLength(300, ErrorMessage = "Headline cannot exceed 300 characters")]
        public string Headline { get; set; } = null!;

        [Required(ErrorMessage = "Content is required")]
        public string NewsContent { get; set; } = null!;

        [StringLength(500, ErrorMessage = "News source cannot exceed 500 characters")]
        public string? NewsSource { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public bool NewsStatus { get; set; } = true; // Default to "Active"

        public int CreatedById { get; set; }

        public int? UpdatedById { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual SystemAccount CreatedBy { get; set; } = null!;

        public virtual SystemAccount? UpdatedBy { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
