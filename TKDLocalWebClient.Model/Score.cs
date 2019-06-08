using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TKDLocalWebClient.Model
{
    public class Score
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Round { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public double MinorMean { get; set; }
        [Required]
        public double MinorTotal { get; set; }
        [Required]
        public double GrandTotal { get; set; }
        [Required]
        public double AccuracyMinorTotal { get; set; }
        [Required]
        public double PresentationMinorTotal { get; set; }
        [Required]
        public double AccuracyGrandTotal { get; set; }
        [Required]
        public double PresentationGrandTotal { get; set; }

        public double Presentation1 { get; set; }
        public double Presentation2 { get; set; }
        public double Presentation3 { get; set; }
        public double Presentation4 { get; set; }
        public double Presentation5 { get; set; }
        public double Presentation6 { get; set; }
        public double Presentation7 { get; set; }
        public double Presentation8 { get; set; }
        public double Presentation9 { get; set; }

        public double Accuracy1 { get; set; }
        public double Accuracy2 { get; set; }
        public double Accuracy3 { get; set; }
        public double Accuracy4 { get; set; }
        public double Accuracy5 { get; set; }
        public double Accuracy6 { get; set; }
        public double Accuracy7 { get; set; }
        public double Accuracy8 { get; set; }
        public double Accuracy9 { get; set; }


        [ForeignKey(nameof(Contestant))]
        public int ContestantId { get; set; }
        public virtual Contestant Contestant { get; set; }


    }
}
