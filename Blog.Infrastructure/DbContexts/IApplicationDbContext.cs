using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DbContexts;

public interface IApplicationDbContext
{
    DbSet<BlogPost> BlogPosts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}