using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Friend;
using SocialMedia.Data;
using SocialMedia.Model;
using SocialMedia.Model.Enums;
using Xunit;

namespace SocialMedia.Tests.FriendServiceTests
{
    public class UpdateFriendTests
    {
        private SocialMediaDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<SocialMediaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new SocialMediaDbContext(options);
        }

        [Fact]
        public async void UpdateFriend_ChangesStatus()
        {
            using var context = GetContext();
            var service = new FriendService(context);

            var friend = new Friend { FromUserId = 1, ToUserId = 2, Status = FriendStatus.Pending };
            context.Add(friend);
            context.SaveChanges();

            friend.Status = FriendStatus.Accepted;
            var result = await service.UpdateFriend(friend);

            var updated = context.Friend.Single();
            Assert.True(result);
            Assert.Equal(FriendStatus.Accepted, updated.Status);
        }
    }
}
