﻿using Api.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities
{
    [Table(nameof(Role))]
    public class Role//Principle
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        internal static IEnumerable<Role> GetInitialData()
        {
            return new List<Role>()
            {
                new Role() { Id = DatabaseConstants.Roles.Admin.Id,Name= DatabaseConstants.Roles.Admin.Name },
                new Role() { Id = DatabaseConstants.Roles.Customer.Id,Name= DatabaseConstants.Roles.Customer.Name }
            };
        }
    }
}