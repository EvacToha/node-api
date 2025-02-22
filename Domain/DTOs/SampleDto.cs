﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.DTOs;

public class SampleDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public DateTime CreateDate { get; set; }
    [Required]
    public int NodeId { get; set; }

    [Required]
    public string CreatedBy { get; set; } = "";
}

