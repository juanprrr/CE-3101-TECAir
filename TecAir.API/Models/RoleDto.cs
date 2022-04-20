﻿using System.ComponentModel.DataAnnotations;

namespace TecAir.API.Models
{
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
