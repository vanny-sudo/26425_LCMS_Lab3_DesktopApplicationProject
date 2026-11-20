using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Model
{
    public class User
    {
            public int UserId { get; set; }
            public int? ClientId { get; set; }
            public string Username { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime? DateOfBirth { get; set; }
        }
    }
