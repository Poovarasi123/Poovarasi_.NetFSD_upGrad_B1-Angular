using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HandsOnEFCodeFirstRelations.Entities
{
    internal class Product
    {
        [Key] // set Id as primary key column
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // auto identity disable
        public int Id { get; set; }

        [Required] // applied not null constraint
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string? Name { get; set; }

        public int? Price { get; set; } // set column as null
    }
}