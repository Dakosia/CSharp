using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Shared.Models
{
    public class BookRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PersonCount { get; set; }
        public decimal TourTotalCost { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public BookRecord()
        {

        }

        public BookRecord(int Id, int ClientId, int PersonCount, decimal TourTotalCost, DateTime DepartureDate, DateTime ReturnDate)
        {
            this.Id = Id;
            this.ClientId = ClientId;
            this.PersonCount = PersonCount;
            this.TourTotalCost = TourTotalCost;
            this.DepartureDate = DepartureDate;
            this.ReturnDate = ReturnDate;
        }
    }
}
