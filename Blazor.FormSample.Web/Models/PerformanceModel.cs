using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FormSample.Web.Models
{
    public class PerformanceModel
    {
        public Guid Id { get; set; }

        [Required] [MaxLength(200)] public string Name { get; set; }

        public PerformanceModel()
        {
            Id = Guid.NewGuid();
            Name = $"Test {Id}";
        }
    }

    public class PerformanceContainer
    {
        public List<PerformanceModel> PerformanceTests { get; set; } = new();
    }
}