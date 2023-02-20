using System.ComponentModel.DataAnnotations;

namespace BIerlager2
{
    public class Kiste
    {
        private static int count = 0;

        public Kiste()
        {
            count++;
        }
        public int GetCount()
        {
            return count;
        }

        [Key]
        public int KisteId { get; set; }
        public int Volumen { get; set; }
        public int Raum { get; set; }
        public int Regal { get; set; }
    }
}
