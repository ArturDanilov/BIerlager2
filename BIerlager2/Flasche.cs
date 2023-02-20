using System.ComponentModel.DataAnnotations;

namespace BIerlager2
{
    public class Flasche
    {
        //при создании объекта класса Flasche его int count увеличивается на 1
        [Key]
        public Guid FlascheId { get; set; }
        public string Name { get; set; }
        public DateTime GenommenAm { get; set; }
        public int KisteId { get; set; }
        public int Raum { get; set; }
        public int Regal { get; set; }
    }
}
