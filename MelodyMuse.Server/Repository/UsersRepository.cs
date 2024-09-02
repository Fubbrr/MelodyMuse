﻿using MelodyMuse.Server.models;
using MelodyMuse.Server.Models;
using MelodyMuse.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MelodyMuse.Server.Repository
{
    // 用户仓库类，实现IUsersRepository接口
    public class UsersRepository : IUsersRepository
    {
        private readonly ModelContext _context;

        // 构造函数，创建新的ModelContext对象
        public UsersRepository()
        {
            _context = new ModelContext();
        }

        // 根据用户ID获取用户信息
        public async Task<UserModel> GetUserById(string userId)
        {
            // 在数据库中查找是否有该用户ID，返回该用户的数据
            var userData = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (userData == null)
            {
                return null;
            }
            // 创建新用户对象
            var user = new UserModel
            {
                UserId = userData.UserId,
                UserName = userData.UserName,
                Password = userData.Password,
                UserEmail = userData.UserEmail,
                UserPhone = userData.UserPhone,
                UserSex = userData.UserSex,
                UserAge = userData.UserAge,
                UserBirthday = userData.UserBirthday,
                UserStatus = userData.UserStatus
            };

            return user;
        }

        // 更新用户资料
        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);

            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.UserEmail = user.UserEmail;
                existingUser.UserPhone = user.UserPhone;
                existingUser.UserSex = user.UserSex;
                existingUser.UserAge = user.UserAge;
                existingUser.UserBirthday = user.UserBirthday;
                existingUser.UserStatus = user.UserStatus;

                await _context.SaveChangesAsync();
            }
        }

        //更新用户数据
        public async Task<User?> UpdateUserStatus(string userId, string newStatus)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return null; // 返回 null 表示用户不存在
            }

            // 如果 newStatus 不为空，并且与当前状态不同，则更新用户状态
            if (!string.IsNullOrEmpty(newStatus) && newStatus != user.UserStatus)
            {
                user.UserStatus = newStatus;
                await _context.SaveChangesAsync();
            }

            var newUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            return newUser; // 返回更新后的用户对象
        }

        //获取用户列表
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserUpload(Upload upload)
        {
            _context.Uploads.Add(upload);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUploadRecord(string userId, string songId)
        {
            // 查找Uploads表中是否存在指定的userId和songId
            var uploadRecord = await _context.Uploads.FirstOrDefaultAsync(u => u.UserId == userId && u.SongId == songId);

            // 如果找到了对应的记录
            if (uploadRecord != null)
            {
                // 删除该记录
                _context.Uploads.Remove(uploadRecord);

                // 保存更改并返回结果
                return await _context.SaveChangesAsync() > 0;
            }

            // 如果没有找到对应的记录
            return true;
        }
        public async Task<bool> DeleteCollectSongRecord(string songId)
        {
            // 查找所有收藏了指定SongId的记录
            var records = await _context.UserCollectSongs
                .Where(u => u.SongId == songId)
                .ToListAsync();

            // 如果存在相关记录，进行删除
            if (records.Any())
            {
                _context.UserCollectSongs.RemoveRange(records);
                return await _context.SaveChangesAsync() > 0;
            }

            // 如果没有找到相关记录
            return true;

        }
    }
}
