using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_2_Web_API___42563690.Repository.Models;

[Table("JobTelemetry", Schema = "Telemetry")]
public partial class JobTelemetry
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ProccesID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProccesId { get; set; }

    [Column("JobID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? JobId { get; set; }

    [Column("QueueID")]
    [Unicode(false)]
    public string? QueueId { get; set; }

    [Unicode(false)]
    public string? StepDescription { get; set; }

    public int? HumanTime { get; set; }

    [Unicode(false)]
    public string? UniqueReference { get; set; }

    [Unicode(false)]
    public string? UniqueReferenceType { get; set; }

    [Unicode(false)]
    public string? BusinessFunction { get; set; }

    [Unicode(false)]
    public string? Geography { get; set; }

    public bool? ExcludeFromTimeSaving { get; set; }

    [Unicode(false)]
    public string? AdditionalInfo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }


    //For the table Project
    [Key]
    [Column(TypeName ="ProjectID")]
    public Guid ProjectID { get; set; }

    // Navigation property
    public Project Project { get; set; }
}
