using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewsApi.Services.Comments.Contracts;
using NewsApi.Services.Comments.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;

namespace NewsApi.Persistence.Ef.Comments
{
    public class EfCommentRepository : CommentRepository
    {
        private readonly DbSet<Comment> _comment;

        public EfCommentRepository(EfDataContext efDataContext)
        {
            _comment = efDataContext.Comments;
        }

        public async Task<List<GetCommentDto>> GetAll()
        {
            return await _comment.Select(x => new GetCommentDto
            {
                Name = x.Name,
                Text = x.Text,
                CommentStatus = x.CommentStatus,
                NewsId = x.NewsId,

            }).ToListAsync();
        }

        public async Task<List<GetCommentDto>> GetAllByNews(
            int id,
            [FromQuery] CommentStatus commentStatus)
        {
            return await _comment.Where(_ => _.NewsId == id && _.CommentStatus == commentStatus)
                .Select(x => new GetCommentDto
            {
                Name = x.Name,
                Text = x.Text,
                CommentStatus = x.CommentStatus,
                NewsId = x.NewsId,

            }).ToListAsync();         }

        public void Add(Comment comment)
        {
             _comment.Add(comment);

        }

        public async Task<Comment> GetById(int id)
        {
            return await _comment.FindAsync(id);

        }

        public void Update(Comment comment)
        {
            _comment.Update(comment);
        }

    }
}
