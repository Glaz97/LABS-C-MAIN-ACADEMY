using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAiroportASP_NET.Models
{
    [Table("AirflightPriceList")]
    public class AirflightPriceList
    {
        [Key]
        public int PriceListID { get; set; }
        public int AirFlightID { get; set; }
        public int Econom { get; set; }
        public int Business { get; set; }
        public int BusinessPlus { get; set; }

        public AirflightPriceList() { }
    }
}