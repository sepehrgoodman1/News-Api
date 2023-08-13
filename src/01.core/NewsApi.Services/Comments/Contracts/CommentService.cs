using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Comments.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Comments.Contracts
{
    public interface CommentService
    {
        Task<List<GetCommentDto>> GetAll();
        Task Add(AddCommentDto comment,CommentStatus commentStatus);
        Task<List<GetCommentDto>> GetAllByNews(int id, [FromQuery] CommentStatus commentStatus);
        Task Update(int id, [FromQuery] CommentStatus commentStatus);
    }
}
