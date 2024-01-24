using Blog.Application.Features.BlogPosts.Commands.CreateBlogPost;
using Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost;
using Blog.Application.Features.BlogPosts.Commands.UpdateBlogPost;
using Blog.Application.Features.BlogPosts.Queries;
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

    [HttpGet(Name = nameof(GetBlogPosts))]
    public async Task<ActionResult<List<BlogPostDto>>> GetBlogPosts()
    {
        return await _mediator.Send(new GetBlogPostsQuery());
    }

    [HttpGet("{id:guid}", Name = nameof(GetBlogPostById))]
    public async Task<BlogPostDto> GetBlogPostById(Guid id)
    {
        return await _mediator.Send(new GetBlogPostByIdQuery(id));
    }

    [HttpPost(Name = nameof(CreateBlogPost))]
    public async Task<Guid> CreateBlogPost(CreateBlogPostCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id:guid}", Name = nameof(UpdateBlogPost))]
    public async Task<IResult> UpdateBlogPost(Guid id, UpdateBlogPostCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await _mediator.Send(command);
        return Results.NoContent();
    }

    [HttpDelete("{id:guid}", Name = nameof(DeleteBlogPost))]
    public async Task<IResult> DeleteBlogPost(Guid id)
    {
        await _mediator.Send(new DeleteBlogPostCommand(id));
        return Results.NoContent();
    }
}