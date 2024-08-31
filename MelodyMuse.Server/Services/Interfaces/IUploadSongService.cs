﻿using MelodyMuse.Server.models;

namespace MelodyMuse.Server.Services.Interfaces
{
    public interface IUploadSongService
    {
        Task<bool> UploadSongAsync(SongUploadModel songUploadDto);
        Task<bool> CreateSongAsync(SongCreateModel song);//批量上传歌曲信息

        Task<bool> UserUploadSongAsync(SongUploadByUserModel songUploadByUserModel,string UserId );//用户上传歌曲
    }
}
