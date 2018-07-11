using KazTourApp.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.DAL
{
    public class BookStorage
    {
        public void AddBooking(BookRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var bookings = db.GetCollection<BookRecord>("bookings");
                bookings.Insert(record);
            }
        }

        public List<BookRecord> ReadAllBookings()
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var bookings = db.GetCollection<BookRecord>("bookings");
                return bookings.FindAll().ToList();
            }
        }

        public void UpdateBooking(int id, BookRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var bookings = db.GetCollection<BookRecord>("bookings");
                bookings.Update(id, record);
            }
        }

        public BookRecord ReadBooking(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var bookings = db.GetCollection<BookRecord>("bookings");
                return bookings.FindOne(x => x.Id == id);
            }
        }

        public void RemoveBooking(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var bookings = db.GetCollection<BookRecord>("bookings");
                bookings.Delete(id);
            }
        }
    }
}
