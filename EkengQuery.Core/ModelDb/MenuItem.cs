using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            Permission = new HashSet<Permission>();
        }

        [Key]
        [Column("MenuItemID")]
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }

        [InverseProperty("MenuItem")]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
