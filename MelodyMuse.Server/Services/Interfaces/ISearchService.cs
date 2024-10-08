﻿/*
   Search服务提供的接口
 */

using MelodyMuse.Server.models;
using MelodyMuse.Server.Models;

namespace MelodyMuse.Server.Services.Interfaces
{
    public interface ISearchService
    {
        Task<List<Artist>> SearchArtists(string query);
        Task<List<SongModel>> SearchSongsByName(string query);
        Task<List<SongSearchModel>> SearchSongsByLyrics(string query);
        Task<List<Artist>> GetArtistsBySongId(string songId);
    }
}
