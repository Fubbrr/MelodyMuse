﻿/*
   用户服务(UserService)提供的接口(IUserService)
 */
using MelodyMuse.Server.models;
using MelodyMuse.Server.Models;


namespace MelodyMuse.Server.Services.Interfaces
{
        public interface IUsersService
        {
                Task<UserModel> GetUserById(string userId);
                Task<User?> UpdateUserStatus(string userId, string newStatus);
                Task<List<string>> GetAllUserIds();
                Task UpdateUserAsync(UserModel user);

                Task AddUserCollectSongAsync(string userId, string songId);
                Task RemoveUserCollectSongAsync(string userId, string songId); // 新增
                Task AddUserCollectAlbumAsync(string userId, string albumId);
                Task RemoveUserCollectAlbumAsync(string userId, string albumId);
                Task<List<Album>> GetUserCollectedAlbumsAsync(string userId);
                Task<List<UserCollectedSongDto>> GetCollectedSongsByUserId(string userId);

                Task<bool> Useridentity(string userId);//判断用户是否已经上传歌曲成为歌手

        }
}
