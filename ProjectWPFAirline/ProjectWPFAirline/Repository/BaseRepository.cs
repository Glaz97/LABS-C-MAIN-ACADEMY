using ProjectWPFAirline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectWPFAirline
{
    public class BaseRepository : MainWindow
    {
        public DBContext db = new DBContext();

        #region ViewModelsObjects
        public List<DataGridAirflightsViewModel> TableDataGridAirflights = new List<DataGridAirflightsViewModel>();
        public List<DataGridPassengersViewModel> TableDataGridPassengers = new List<DataGridPassengersViewModel>();
        public List<DataGridPriceListViewModel> TableDataGridPriceList = new List<DataGridPriceListViewModel>();
        #endregion

        #region LoadingDataFromViewModels
        public List<DataGridAirflightsViewModel> LoadAirflightsData()
        {
            TableDataGridAirflights.Clear();

            foreach (AirflightsModel element in db.Airflights)
            {
                TableDataGridAirflights.Add(
                    new DataGridAirflightsViewModel(
                    element.AirFlightID,
                    element.PriceListID,
                    element.CityDepature.Trim(),
                    element.CityArrival.Trim(),
                    element.AiroportDepature.Trim(),
                    element.AiroportArrival.Trim(),
                    element.FlightNumber.Trim(),
                    element.Terminal.Trim(),
                    element.Gate.Trim(),
                    element.TimeExpected,
                    element.DateAndTimeArival,
                    element.DateAndTimeDepature,
                    element.Status
                    ));
            }
            return TableDataGridAirflights;
        }

        public List<DataGridPassengersViewModel> LoadPassengersData()
        {
            TableDataGridPassengers.Clear();

            foreach (PassengerModel element in db.Passengers)
            {
                TableDataGridPassengers.Add(
                    new DataGridPassengersViewModel(
                    element.PassengerID,
                    element.AirFlightID,
                    element.FirstName.Trim(),
                    element.SecondName.Trim(),
                    element.Nationality.Trim(),
                    element.PassportNumber.Trim(),
                    element.DateOfBirth,
                    element.Sex,
                    element.FlightClass
                    ));
            }
            return TableDataGridPassengers;
        }

        public List<DataGridPriceListViewModel> LoadPriceListData()
        {
            TableDataGridPriceList.Clear();

            foreach (PriceListModel element in db.PriceList)
            {
                TableDataGridPriceList.Add(
                    new DataGridPriceListViewModel(
                    element.PriceListID,
                    element.AirFlightID,
                    element.Econom,
                    element.Business,
                    element.BusinessPlus
                    ));
            }
            return TableDataGridPriceList;
        }
        #endregion

        #region BaseFunctions
        public void MarkCurrentItem(object ChangedElement, int Index)
        {
            if (ChangedElement is DataGridAirflightsViewModel)
            {
                TableDataGridAirflights[Index].IsModified = true;
            }
            else if (ChangedElement is DataGridPassengersViewModel)
            {
                TableDataGridPassengers[Index].IsModified = true;
            }
            else if (ChangedElement is DataGridPriceListViewModel)
            {
                TableDataGridPriceList[Index].IsModified = true;
            }
        }

        public object GetCurrentModifedElement(DataGrid DataGridElement)
        {
            if (DataGridElement.CurrentItem is DataGridAirflightsViewModel)
            {
                var DataGridCollection = (List<DataGridAirflightsViewModel>)DataGridElement.Items.SourceCollection;
                var CurrentElement = DataGridCollection.Find(x => x.IsModified == true);
                if (CurrentElement != null)
                {
                    return CurrentElement;
                }
            }
            else if (DataGridElement.CurrentItem is DataGridPassengersViewModel)
            {
                var DataGridCollection = (List<DataGridPassengersViewModel>)DataGridElement.Items.SourceCollection;
                var CurrentElement = DataGridCollection.Find(x => x.IsModified == true);
                if (CurrentElement != null)
                {
                    return CurrentElement;
                }
            }
            else if (DataGridElement.CurrentItem is DataGridPriceListViewModel)
            {
                var DataGridCollection = (List<DataGridPriceListViewModel>)DataGridElement.Items.SourceCollection;
                var CurrentElement = DataGridCollection.Find(x => x.IsModified == true);
                if (CurrentElement != null)
                {
                    return CurrentElement;
                }
            }

            return null;
        }

        public void UpdateDbInfo(object ChangedElement, int Index)
        {
            if (ChangedElement is DataGridAirflightsViewModel)
            {
                var ElementToInsert = (DataGridAirflightsViewModel)ChangedElement;
                ElementToInsert.IsModified = false;

                if (db.Airflights.Where(x => x.AirFlightID == ElementToInsert.AirFlightID).Count() > 0)
                {
                    UpdateAirflightDbInfo(ElementToInsert);
                }
                else
                {
                    AddAirflightDbInfo(ElementToInsert);
                }
            }
            else if (ChangedElement is DataGridPassengersViewModel)
            {
                var ElementToInsert = (DataGridPassengersViewModel)ChangedElement;
                ElementToInsert.IsModified = false;
                if (db.Passengers.Where(x => x.PassengerID == ElementToInsert.PassengerID).Count() > 0)
                {
                    UpdatePassengersDbInfo(ElementToInsert);
                }
                else
                {
                    AddPassengersDbInfo(ElementToInsert);
                }
            }
            else if (ChangedElement is DataGridPriceListViewModel)
            {
                var ElementToInsert = (DataGridPriceListViewModel)ChangedElement;
                ElementToInsert.IsModified = false;
                if (db.PriceList.Where(x => x.PriceListID == ElementToInsert.PriceListID).Count() > 0)
                {
                    UpdatePriceListDbInfo(ElementToInsert);
                }
                else
                {
                    AddPriceListDbInfo(ElementToInsert);
                }
            }
        }

        public object DeleteCurrentElement(object CurrentItem)
        {
            if (CurrentItem is DataGridAirflightsViewModel)
            {
                var DataGridCurrentItem = (DataGridAirflightsViewModel)CurrentItem;

                db.Airflights.RemoveRange(db.Airflights.Where(x => x.AirFlightID == DataGridCurrentItem.AirFlightID));
                db.SaveChanges();

                return LoadAirflightsData();
            }
            else if (CurrentItem is DataGridPassengersViewModel)
            {
                var DataGridCurrentItem = (DataGridPassengersViewModel)CurrentItem;

                db.Passengers.RemoveRange(db.Passengers.Where(x => x.PassengerID == DataGridCurrentItem.PassengerID));
                db.SaveChanges();

                return LoadPassengersData();
            }
            else if (CurrentItem is DataGridPriceListViewModel)
            {
                var DataGridCurrentItem = (DataGridPriceListViewModel)CurrentItem;

                db.PriceList.RemoveRange(db.PriceList.Where(x => x.PriceListID == DataGridCurrentItem.PriceListID));
                db.SaveChanges();

                return LoadPriceListData();
            }
            return null;
        }
        #endregion

        #region AddDBElement
        public void AddAirflightDbInfo(DataGridAirflightsViewModel Element)
        {
            if (Element.AiroportArrival != "" && Element.AiroportDepature != "" && Element.CityArrival != ""
                && Element.CityDepature != "" && Element.DateAndTimeArival != DateTime.MinValue 
                && Element.DateAndTimeDepature != DateTime.MinValue && Element.FlightNumber != "" 
                && Element.Gate != "" && Element.PriceListID != 0 && Element.Status != 0 
                && Element.Terminal != "" && Element.TimeExpected != DateTime.MinValue)
            {
                try
                {
                    db.Airflights.Add((AirflightsModel)Element);
                    db.SaveChanges();
                    LoadAirflightsData();
                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show("Ошибка при попытке записи строки новых рейсов! Проверьте введеные данные!");
                    LogTextBox.Text = e.Message;
                }
            }
        }

        public void AddPassengersDbInfo(DataGridPassengersViewModel Element)
        {
            if (Element.AirFlightID != 0 && Element.DateOfBirth != DateTime.MinValue &&
                Element.FirstName != "" && Element.FlightClass != 0 && Element.Nationality != ""
                && Element.PassportNumber != "" && Element.SecondName != "" && Element.Sex != 0)
            {
                try
                {
                    db.Passengers.Add((PassengerModel)Element);
                    db.SaveChanges();
                    LoadPassengersData();
                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show("Ошибка при попытке записи строки новых пассажиров! Проверьте введеные данные!");
                    LogTextBox.Text = e.Message;
                }
            }
        }

        public void AddPriceListDbInfo(DataGridPriceListViewModel Element)
        {
            if (Element.AirFlightID != 0 && Element.Business != 0 && Element.BusinessPlus != 0 && Element.Econom != 0)
            {
                try
                {
                    db.PriceList.Add((PriceListModel)Element);
                    db.SaveChanges();
                    LoadPriceListData();
                }
                catch (InvalidCastException e)
                {
                    MessageBox.Show("Ошибка при попытке записи строки новых цен! Проверьте введеные данные!");
                    LogTextBox.Text = e.Message;
                }
            }
        }
        #endregion

        #region UpdateDBElement
        public void UpdateAirflightDbInfo(DataGridAirflightsViewModel ChangedElementDictionary)
        {
            var elementToChange = db.Airflights.Where(x => x.AirFlightID == ChangedElementDictionary.AirFlightID)
                .Select(x => x).First();

            elementToChange.CityDepature = ChangedElementDictionary.CityDepature;
            elementToChange.CityArrival = ChangedElementDictionary.CityArrival;
            elementToChange.AiroportDepature = ChangedElementDictionary.AiroportDepature;
            elementToChange.AiroportArrival = ChangedElementDictionary.AiroportArrival;
            elementToChange.FlightNumber = ChangedElementDictionary.FlightNumber;
            elementToChange.Terminal = ChangedElementDictionary.Terminal;
            elementToChange.Gate = ChangedElementDictionary.Gate;
            elementToChange.TimeExpected = ChangedElementDictionary.TimeExpected;
            elementToChange.DateAndTimeArival = ChangedElementDictionary.DateAndTimeArival;
            elementToChange.DateAndTimeDepature = ChangedElementDictionary.DateAndTimeDepature;
            elementToChange.Status = ChangedElementDictionary.Status;
            elementToChange.AiroportArrival = ChangedElementDictionary.AiroportArrival;

            db.SaveChanges();
        }

        public void UpdatePassengersDbInfo(DataGridPassengersViewModel ChangedElementDictionary)
        {
            var elementToChange = db.Passengers.Where(x => x.PassengerID == ChangedElementDictionary.PassengerID)
                .Select(x => x).First();

            elementToChange.FirstName = ChangedElementDictionary.FirstName;
            elementToChange.SecondName = ChangedElementDictionary.SecondName;
            elementToChange.Nationality = ChangedElementDictionary.Nationality;
            elementToChange.PassportNumber = ChangedElementDictionary.PassportNumber;
            elementToChange.DateOfBirth = ChangedElementDictionary.DateOfBirth;
            elementToChange.Sex = ChangedElementDictionary.Sex;
            elementToChange.FlightClass = ChangedElementDictionary.FlightClass;

            db.SaveChanges();
        }

        public void UpdatePriceListDbInfo(DataGridPriceListViewModel ChangedElementDictionary)
        {
            var elementToChange = db.PriceList.Where(x => x.PriceListID == ChangedElementDictionary.PriceListID)
                .Select(x => x).First();

            elementToChange.AirFlightID = ChangedElementDictionary.AirFlightID;
            elementToChange.Econom = ChangedElementDictionary.Econom;
            elementToChange.Business = ChangedElementDictionary.Business;
            elementToChange.BusinessPlus = ChangedElementDictionary.BusinessPlus;

            db.SaveChanges();
        }
        #endregion

        #region SeacrhDBElement
        public object FindAiroportInfoElements (string AskString)
        {
           return db.Airflights.Where(x => x.FlightNumber == AskString 
           || x.AiroportArrival == AskString || x.AiroportDepature == AskString).ToList();
        }

        public object FindPassengersInfoElements(string AskString)
        {
            return db.Passengers.Where(x => x.FirstName == AskString || 
            x.Nationality == AskString || x.SecondName == AskString || x.PassportNumber == AskString).ToList();
        }

        public object FindPriceListInfoElements(string AskString)
        {
            int.TryParse(AskString, out int price);

            var priceLists = db.PriceList.Where(x=>x.Business == price || x.BusinessPlus == price || x.Econom == price).ToList();

            List<AirflightsModel> listOfAirflights = new List<AirflightsModel>();

            foreach (var element in priceLists)
            {
                foreach (var airflight in db.Airflights.Where(z => z.AirFlightID == element.AirFlightID))
                {
                    listOfAirflights.Add(airflight);
                }
            }

            return listOfAirflights;
        }
        #endregion
    }
}
