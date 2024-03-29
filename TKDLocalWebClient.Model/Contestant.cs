﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKDLocalWebClient.Model
{
    public class Contestant
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string TrackPath { get; set; }
        

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Score> Scores { get; set; }


        public string FullName => Name + (!string.IsNullOrEmpty(Surname) ? " " + Surname : "");
    }
}
