using AutoMapper;
using Blog.Application.Features.BlogPosts.Queries;
using Blog.Domain.Models;

namespace Blog.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogPostDto, BlogPost>().ReverseMap();
    }
}