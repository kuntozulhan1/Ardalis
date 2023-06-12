using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarkUnionEngine.SharedKernel
{
    public abstract class BaseEntity
    {
        [Column(Order = 0)]
        public System.Int64 Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Column("CreatedBy")]
        [Display(Name = "Creator")]
        public string CreatedBy { get; set; }

        [Column("ModifiedBy")]
        [Display(Name = "Modifier")]
        public string ModifiedBy { get; set; }
         
        public string CreatedByWithUserNameOnly { get { if (this.CreatedBy != null) { if (this.CreatedBy.Contains("|")) { return this.CreatedBy.Split("|")[0]; } else { return this.CreatedBy; } } else { return "N/A"; } } }
        public string CreatedAtFormated { get { return this.CreatedAt.ToString("dd MMM yyyy HH:mm:ss"); } }

        public string ModifiedByWithUserNameOnly { get { if (this.ModifiedBy != null) { if (this.ModifiedBy.Contains("|")) { return this.ModifiedBy.Split("|")[0]; } else { return this.ModifiedBy; } } else { return "N/A"; } } }
        public string ModifiedAtFormated { get { return this.ModifiedAt.HasValue ? this.ModifiedAt.Value.ToString("dd MMM yyyy HH:mm:ss") : "N/A"; } }


        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        public string DeletedByWithUserNameOnly { get { if (this.DeletedBy != null) { if (this.DeletedBy.Contains("|")) { return this.DeletedBy.Split("|")[0]; } else { return this.CreatedBy; } } else { return "N/A"; } } }
        
        public string DeletedAtFormated { get { return this.DeletedAt.HasValue ? this.DeletedAt.Value.ToString("dd MMM yyyy HH:mm:ss") : "N/A"; } }


    }
}