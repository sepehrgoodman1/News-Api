using NewsApi.Services.Comments.Contracts;
using NewsApi.Services.Groups.Contracts.Dtos;
using NewsApi.Services.Groups.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts.Interfaces;
using NewsApi.Services.Comments.Contracts.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Services.Comments.Exceptions;

namespace NewsApi.Services.Comments
{
    public class CommentAppService : CommentService
    {
        private readonly CommentRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public CommentAppService(CommentRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetCommentDto>> GetAll()
        {
            return await _repository.GetAll();

        }

        public async Task<List<GetCommentDto>> GetAllByNews(int id, [FromQuery] CommentStatus commentStatus)
        {
            return await _repository.GetAllByNews(id, commentStatus);
        }

        public async Task Add(AddCommentDto comment,CommentStatus commentStatus)
        {
            var commentDto = new Comment
            {
                Name = comment.Name,
                Text = comment.Text,
                NewsId = comment.NewsId,
                CommentStatus = commentStatus,
            };

            _repository.Add(commentDto);


            await _unitOfWork.Complete();
        }
        public async Task Update(int id, [FromQuery] CommentStatus commentStatus)
        {
            var comment = await _repository.GetById(id);

            if (comment == null)
            {
                throw new CommentNotFoundException();
            }

            comment.CommentStatus = commentStatus;

            _repository.Update(comment);

            await _unitOfWork.Complete();

        }
    }
}
