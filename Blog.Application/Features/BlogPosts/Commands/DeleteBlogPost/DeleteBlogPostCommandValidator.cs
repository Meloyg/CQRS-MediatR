using FluentValidation;

namespace Blog.Application.Features.BlogPosts.Commands.DeleteBlogPost;

public class DeleteBlogPostCommandValidator : AbstractValidator<DeleteBlogPostCommand>
{
    public DeleteBlogPostCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}