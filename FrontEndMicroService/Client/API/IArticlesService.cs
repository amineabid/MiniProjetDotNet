using FrontEndMicroService.Client.Models;
using System;
using System.Net.Http.Json;

namespace FrontEndMicroService.Client.API
{

    public interface IArticlesService
    {
        public Task<List<Article>> GetAll();
        public Task<Article> Create(Article Article);
        public Task<Article> Edit(Article Article);
        public Task<Article> Delete(int id);
        Task<List<Piece>> GetPiecesArtciles(int articleId);
        Task<Piece> CreatePiece(Piece Piece);
        Task<Piece> EditPiece(Piece Piece);
        Task<Piece> DeletePiece(int id);

    }
}
