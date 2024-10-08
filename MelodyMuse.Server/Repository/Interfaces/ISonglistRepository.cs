﻿using MelodyMuse.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISonglistRepository
{
    Task<IEnumerable<(string SonglistId, string SonglistName, int SongCount)>> GetUserSonglistsWithSongCountAsync(string userId);
    Task<IEnumerable<Song>> GetSongsBySonglistIdAsync(string songlistId);
    Task<string> AddSonglistAsync(Songlist songlist);
    Task<bool> DeleteSonglistAsync(string songlistId, string userId);
    Task<int> AddSongToSonglistAsync(string songlistId, string songId, string userId);
    Task<bool> DeleteSongFromSonglistAsync(string songlistId, string songId, string userId);
    Task<Songlist> GetSonglistByIdAsync(string songlistId);
    Task UpdateSonglistAsync(Songlist songlist);
    Task<Songlist> GetSonglistBySonglistIdAsync(string songlistId);
}
