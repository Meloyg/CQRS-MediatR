using Blog.Domain.Models;
using Blog.Infrastructure.DbContexts;
using MediatR;

namespace Blog.Application.Features.BlogPosts.Commands.CreateBlogPost;

public record CreateBlogPostCommand() : IRequest<Guid>
{
    public string? Title { get; set; }
    public string? Category { get; set; }
    public string? Content { get; set; }
}

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateBlogPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = new BlogPost
        {
            Title = request.Title,
            Category = request.Category,
            Content = request.Content
        };

        _context.BlogPosts.Add(blogPost);

        await _context.SaveChangesAsync(cancellationToken);

        return blogPost.Id;
    }
}