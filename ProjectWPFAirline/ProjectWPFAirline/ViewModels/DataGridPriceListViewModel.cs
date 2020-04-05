using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPFAirline.ViewModels
{
    public class DataGridPriceListViewModel
    {
        public int PriceListID { get; set; }
        public int AirFlightID { get; set; }
        public int Econom { get; set; }
        public int Business { get; set; }
        public int BusinessPlus { get; set; }
        public bool IsModified { get; set; }

        public DataGridPriceListViewModel() { }

        public DataGridPriceListViewModel(int priceListID, int airFlightID, int econom, int business, int businessPlus)
        {
            PriceListID = priceListID;
            AirFlightID = airFlightID;
            Econom = econom;
            Business = business;
            BusinessPlus = businessPlus;
        }
    }
}
