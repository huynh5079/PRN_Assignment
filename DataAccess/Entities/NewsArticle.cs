using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class NewsArticle
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool Status { get; set; }

    public virtual Account Author { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
