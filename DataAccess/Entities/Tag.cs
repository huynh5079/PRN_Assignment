using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? NewsArticleId { get; set; }

    public virtual NewsArticle? NewsArticle { get; set; }
}
