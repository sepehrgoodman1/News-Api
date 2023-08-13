using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Comments.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Services.Comments.Contracts
{
    public interface CommentRepository
    {
        Task<List<GetCommentDto>> GetAll();
        void Add(Comment comment);
        Task<List<GetCommentDto>> GetAllByNews(int id, [FromQuery] CommentStatus commentStatus);
        void Update(Comment comment);
        Task<Comment> GetById(int id);
    }
}
