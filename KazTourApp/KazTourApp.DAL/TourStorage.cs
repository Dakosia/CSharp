using KazTourApp.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.DAL
{
    public class TourStorage
    {
        public void AddTour(TourRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                tours.Insert(record);
            }
        }

        public List<TourRecord> ReadAllTours()
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                return tours.FindAll().ToList();
            }
        }

        public void UpdateTour(int id, TourRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                tours.Update(id, record);
            }
        }

        public TourRecord ReadTour(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                return tours.FindOne(x => x.Id == id);
            }
        }

        public void RemoveTour(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var tours = db.GetCollection<TourRecord>("tours");
                tours.Delete(id);
            }
        }
    }
}
