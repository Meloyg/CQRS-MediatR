﻿using Ardalis.GuardClauses;
using Blog.Infrastructure.DbContexts;
using MediatR;

namespace Blog.Application.Features.BlogPosts.Commands.UpdateBlogPost;

public record UpdateBlogPostCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Category { get; set; }
    public string? Content { get; set; }
}

public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBlogPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.BlogPosts.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title!;
        entity.Category = request.Category!;
        entity.Content = request.Content!;

        await _context.SaveChangesAsync(cancellationToken);
    }
}