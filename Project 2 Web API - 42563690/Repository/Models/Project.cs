using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_2_Web_API___42563690.Repository.Models;

[Table("Project", Schema = "Config")]
public partial class Project
{
    [Key]
    [Column("ProjectID")]
    public Guid ProjectId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ProjectName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ProjectDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProjectCreationDate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ProjectStatus { get; set; }

    [Column("ClientID")]
    public Guid? ClientId { get; set; }

    //Add the ClientID
    public Guid? ClientID { get; set; } // Nullable in case not all projects are linked to a client

    // Navigation property to link to the Client model
    public Client Client { get; set; }

    // Navigation property to link to JobTelemetries
    public ICollection<JobTelemetry> JobTelemetries { get; set; }
}
