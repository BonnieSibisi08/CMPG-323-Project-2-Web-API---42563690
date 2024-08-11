using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_2_Web_API___42563690.Repository.Models;

[Table("Client", Schema = "Config")]
public partial class Client
{
    [Key]
    [Column("ClientID")]
    public Guid ClientId { get; set; }

    public string? ClientName { get; set; }

    public string? PrimaryContactEmail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateOnboarded { get; set; }

    // Navigation property
    public ICollection<Project> Projects { get; set; }
}
