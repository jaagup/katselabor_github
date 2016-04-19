namespace katselabor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kogustetabel")]
    public partial class kogustetabel
    {
        public int Id { get; set; }
        public int kogus { get; set; }
    }
}
