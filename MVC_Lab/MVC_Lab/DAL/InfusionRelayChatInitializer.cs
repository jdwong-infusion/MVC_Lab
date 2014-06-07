using System.Collections.Generic;
using System.Data.Entity;
using MVC_Lab.Models;

namespace MVC_Lab.DAL
{
    public class InfusionRelayChatInitializer : DropCreateDatabaseIfModelChanges<InfusionRelayChatContext>
    {
        protected override void Seed(InfusionRelayChatContext context)
        {
            var users = new List<User>
                {
                    new User{UserId = 1, UserName = "ChadBroChill", Password = "123456", ConfirmPassword = "123456", RealName = "John", Email = "", About = "abc", Status = Status.Online},
                    new User{UserId = 2, UserName = "LiveLoveLaugh", Password = "123456", ConfirmPassword = "123456", RealName = "Jane", Email = "", About = "def", Status = Status.Online},
                    new User{UserId = 3, UserName = "MrsKanyeWest", Password = "123456", ConfirmPassword = "123456", RealName = "Mary", Email = "", About = "ghi", Status = Status.Offline},
                    new User{UserId = 4, UserName = "BiebsFan111", Password = "123456", ConfirmPassword = "123456", RealName = "Bob", Email = "", About = "jkl", Status = Status.Offline},
                    new User{UserId = 5, UserName = "Hacker1337", Password = "123456", ConfirmPassword = "123456", RealName = "Hacker", Email = "", About = "<script>alert('hacked!');</script>", Status = Status.Unknown}
                };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            // Uncomment once models have been implemented
            var chatrooms = new List<Chatroom>
                {
                    new Chatroom{ChatroomId = 1, Name = "Politics", Description = ""},
                    new Chatroom{ChatroomId = 2, Name = "Finance", Description = ""},
                    new Chatroom{ChatroomId = 3, Name = "Religion", Description = ""},
                    new Chatroom{ChatroomId = 4, Name = "Books", Description = ""},
                    new Chatroom{ChatroomId = 5, Name = "Music", Description = ""},
                    new Chatroom{ChatroomId = 6, Name = "Food", Description = "Omnomnomnomnom"}
                };
            chatrooms.ForEach(c => context.Chatrooms.Add(c));
            context.SaveChanges();

            var subscriptions = new List<Subscription>
                {
                    new Subscription{UserId = 1, ChatroomId = 4},
                    new Subscription{UserId = 1, ChatroomId = 5},
                    new Subscription{UserId = 1, ChatroomId = 6},
                    new Subscription{UserId = 2, ChatroomId = 2},
                    new Subscription{UserId = 2, ChatroomId = 3},
                    new Subscription{UserId = 2, ChatroomId = 6},
                    new Subscription{UserId = 3, ChatroomId = 1},
                    new Subscription{UserId = 3, ChatroomId = 2},
                    new Subscription{UserId = 3, ChatroomId = 4},
                    new Subscription{UserId = 4, ChatroomId = 1},
                    new Subscription{UserId = 4, ChatroomId = 3},
                    new Subscription{UserId = 4, ChatroomId = 5},
                    new Subscription{UserId = 5, ChatroomId = 1},
                    new Subscription{UserId = 5, ChatroomId = 2},
                    new Subscription{UserId = 5, ChatroomId = 3},
                    new Subscription{UserId = 5, ChatroomId = 4},
                    new Subscription{UserId = 5, ChatroomId = 5},
                    new Subscription{UserId = 5, ChatroomId = 6}
                };
            subscriptions.ForEach(s => context.Subscriptions.Add(s));
            context.SaveChanges();
        }
    }
}