using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectWPFAirline.ViewModels;

namespace ProjectWPFAirline
{
    [Table("AirflightPriceList")]
    public class PriceListModel
    {
        [Key]
        public int PriceListID { get; set; }
        public int AirFlightID { get; set; }
        public int Econom { get; set; }
        public int Business { get; set; }
        public int BusinessPlus { get; set; }

        public PriceListModel() { }

        public PriceListModel(int priceListID, int airFlightID, int econom, int business, int businessPlus)
        {
            PriceListID = priceListID;
            AirFlightID = airFlightID;
            Econom = econom;
            Business = business;
            BusinessPlus = businessPlus;
        }

        public static explicit operator PriceListModel(DataGridPriceListViewModel ViewModel)
        {
            PriceListModel priceListModel = new PriceListModel
            {
                PriceListID = ViewModel.PriceListID,
                AirFlightID = ViewModel.AirFlightID,
                Econom = ViewModel.Econom,
                Business = ViewModel.Business,
                BusinessPlus = ViewModel.BusinessPlus
            };

            return priceListModel;
        }
    }
}
