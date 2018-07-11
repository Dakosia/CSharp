using KazTourApp.DAL;
using KazTourApp.Shared.Models;
using KazTourApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.BLL
{
    public class TourService
    {
        private TourStorage _tourStorage;
        private BookStorage _bookStorage;
        private ClientStorage _clientStorage;

        public List<TourRecord> FilterByCriteria(TourSearchRequest request)
        {
            var allTours = _tourStorage.ReadAllTours()
              .Where(x => x.Country == request.ToCountry &&
                          x.MaxPersonsAllowed >= request.PersonCount);

            List<TourRecord> filteredTourRecords = new List<TourRecord>();

            foreach (var item in allTours)
                foreach (var date in item.StartTimes)
                    for (int i = -request.DepartureDateOffset; i <= request.DepartureDateOffset; i++)
                        if (request.DepartureDate.AddDays(i) == date)
                            filteredTourRecords.Add(item);

            return filteredTourRecords;
        }

        public void BuyTicket(TourSearchRequest request)
        {
            List<TourRecord> allTours = _tourStorage.ReadAllTours();
            for (int i = 0; i < allTours.Count; i++)
                if (allTours[i].Country == request.ToCountry)
                    for (int j = 0; j < allTours[i].StartTimes.Length; j++)
                        if (allTours[i].StartTimes[j] == request.DepartureDate)
                            allTours[i].PlacesLeft[j] -= request.PersonCount;
        }

        public int CalculateTourPopularity(TourRecord record)
        {
            int TourPopularity = 0;
            List<TourRecord> allTours = _tourStorage.ReadAllTours();

            for (int i = 0; i < allTours.Count(); i++)
                if (allTours[i].Country == record.Country)
                    TourPopularity++;

            return TourPopularity;
        }

        public decimal CalculateFinalPrice(TourSearchRequest request, List<TourRecord> records)
        {
            decimal FinalPrice = 0;

            for (int i = 0; i < records.Count(); i++)
            {
                if (records[i].Country == request.ToCountry)
                {
                    for (int j = 0; j < records[i].StartTimes.Length; j++)
                    {
                        if (records[i].StartTimes[j] == request.DepartureDate)
                        {
                            FinalPrice += records[i].BasePriceForPerson * request.PersonCount;

                            DateTime date1 = records[i].StartTimes[j];
                            DateTime date2 = DateTime.Now;
                            TimeSpan span = date1 - date2;
                            double days = span.TotalDays;

                            if (days < 10)
                                FinalPrice += FinalPrice * 10 / 100;
                            if (records[i].PlacesLeft[j] < 3)
                                FinalPrice += FinalPrice * 15 / 100;
                        }
                    }
                }
            }

            return FinalPrice;
        }

        public List<TourSearchResponse> GetTourSearchResponse(TourSearchRequest request)
        {
            List<TourRecord> filteredTourRecords = FilterByCriteria(request);
            decimal FinalPrice = CalculateFinalPrice(request, filteredTourRecords);

            List<TourSearchResponse> responses = new List<TourSearchResponse>();
            for (int i = 0; i < filteredTourRecords.Count; i++)
                responses.Add(new TourSearchResponse(filteredTourRecords[i].Name, filteredTourRecords[i].City, CalculateTourPopularity(filteredTourRecords[i]), FinalPrice));
            return responses;
        }

        public TourService()
        {
            _tourStorage = new TourStorage();
        }

        public TourService(TourStorage _tourStorage)
        {
            this._tourStorage = _tourStorage;
        }
    }
}
