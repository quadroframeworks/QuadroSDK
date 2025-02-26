﻿using Quadro.Globalization;

namespace Quadro.Interface.Authorization
{
	public interface IUser
    {
        string Id { get; }
        string CompanyId { get; set; } 
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        Language Language { get; set; }
        UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Administrator,
        Customer,
        User,
        EndCustomer,
    }
}
