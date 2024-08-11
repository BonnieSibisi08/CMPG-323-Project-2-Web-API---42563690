using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_2_Web_API___42563690.Repository.Models;

[Table("Process", Schema = "Config")]
public partial class Process
{
    [Key]
    [Column("ProcessID")]
    public Guid ProcessId { get; set; }

    [Unicode(false)]
    public string ProcessName { get; set; } = null!;

    [Unicode(false)]
    public string ProcessType { get; set; } = null!;

    public bool IsFramework { get; set; }

    public bool RequiresDefaultConfig { get; set; }

    [Unicode(false)]
    public string Submitter { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateSubmitted { get; set; }

    [Column("ProcessConfigURL")]
    [Unicode(false)]
    public string? ProcessConfigUrl { get; set; }

    [Column("ReportURL")]
    [Unicode(false)]
    public string? ReportUrl { get; set; }

    [Column("ProjectID")]
    public Guid? ProjectId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DefaultGeography { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DefaultBusinessFunction { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Platform { get; set; }
}
