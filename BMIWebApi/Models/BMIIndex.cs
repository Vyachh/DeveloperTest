using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMIWebApi.Models
{
    public class BMIIndex
    {
        [Key]
        public int Id { get; set; }
        public int PacientId { get; set; }
        public double Index { get; set; }

        public Pacient Pacient { get; set; }
    }
}
