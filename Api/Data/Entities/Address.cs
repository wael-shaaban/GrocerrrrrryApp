﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities
{
    [Table(nameof(Address))]
    public class Address
    {
        [Key]
        public long Id { get; set; }
        [Required,MaxLength(15)]
        public string Name { get; set; }
        [Required,MaxLength(150)]
        public string Address1 { get; set; }
        [MaxLength(150)]
        public string? Address2 { get; set; }
        [Required, MaxLength(6)]
        public string ZipCode { get; set; }
        public bool IsPrimary { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}