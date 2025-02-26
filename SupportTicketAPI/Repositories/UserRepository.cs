﻿using SupportTicketAPI.Data;
using SupportTicketAPI.Models;

namespace SupportTicketAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public User? GetUserById(string email) => _context.Users.FirstOrDefault(usr => usr.Email == email);

        

    }
}
