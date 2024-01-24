using Blog.Application.Features.BlogPosts.Commands.CreateBlogPost;
using Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogPostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = nameof(CreateBlogPost))]
    public async Task<Guid> CreateBlogPost(CreateBlogPostCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id:guid}", Name = nameof(DeleteBlogPost))]
    public async Task<IResult> DeleteBlogPost(Guid id)
    {
        await _mediator.Send(new DeleteBlogPostCommand(id));
        return Results.NoContent();
    }
}