using KazTourApp.DAL;
using KazTourApp.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.Tests.DalTests
{
    [TestClass]
    public class StorageTests
    {
        [TestClass]
        public class TourStorageTests
        {
            [TestMethod]
            public void Should_Add_Tour_Record_ToDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                var tour = new TourRecord
                    (
                    1,
                    "Tour to Japan, Kyoto",
                    "Japan",
                    "Kyoto",
                    new DateTime[] { new DateTime(2018, 08, 11) },
                    new int[] { 7 },
                    new int[] { 4 },
                    4,
                    800000
                    );

                TourStorage storage = new TourStorage();
                int itemsCountBeforeInsert = storage.ReadAllTours().Count;

                // Act
                storage.AddTour(tour);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterInsert = storage.ReadAllTours().Count;

                Assert.IsTrue(itemsCountBeforeInsert == itemsCountAfterInsert - 1);
            }

            [TestMethod]
            public void Should_Remove_Tour_Record_FromDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                int id = 0;
                TourStorage storage = new TourStorage();
                int itemsCountBeforeDeletion = storage.ReadAllTours().Count;

                // Act
                storage.RemoveTour(id);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterDeletion = storage.ReadAllTours().Count;

                Assert.IsTrue(itemsCountBeforeDeletion == itemsCountAfterDeletion + 1);
            }
        }

        [TestClass]
        public class ClientStorageTests
        {
            [TestMethod]
            public void Should_Add_Client_Record_ToDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                var client = new ClientRecord
                    (
                    1,
                    "Asuna",
                    "Yuuki",
                    "1234567890",
                    "asuna.yuuki@gmail.com"
                    );

                ClientStorage storage = new ClientStorage();
                int itemsCountBeforeInsert = storage.ReadAllClients().Count;

                // Act
                storage.AddClient(client);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterInsert = storage.ReadAllClients().Count;

                Assert.IsTrue(itemsCountBeforeInsert == itemsCountAfterInsert - 1);
            }

            public void Should_Remove_Client_Record_FromDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                int id = 0;
                ClientStorage storage = new ClientStorage();
                int itemsCountBeforeDeletion = storage.ReadAllClients().Count;

                // Act
                storage.RemoveClient(id);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterDeletion = storage.ReadAllClients().Count;

                Assert.IsTrue(itemsCountBeforeDeletion == itemsCountAfterDeletion + 1);
            }
        }

        [TestClass]
        public class BookStorageTests
        {
            [TestMethod]
            public void Should_Add_Book_Record_ToDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                var booking = new BookRecord
                    (
                    1,
                    1,
                    2,
                    1600000,
                    new DateTime(2018, 08, 11),
                    new DateTime(2018, 08, 25)
                    );

                BookStorage storage = new BookStorage();
                int itemsCountBeforeInsert = storage.ReadAllBookings().Count;

                // Act
                storage.AddBooking(booking);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterInsert = storage.ReadAllBookings().Count;

                Assert.IsTrue(itemsCountBeforeInsert == itemsCountAfterInsert - 1);
            }

            public void Should_Remove_Book_Record_FromDb()
            {
                // Arrange
                string pathToFile = @"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db";
                int id = 0;
                BookStorage storage = new BookStorage();
                int itemsCountBeforeDeletion = storage.ReadAllBookings().Count;

                // Act
                storage.RemoveBooking(id);

                // Assert
                Assert.IsTrue(File.Exists(pathToFile));
                
                int itemsCountAfterDeletion = storage.ReadAllBookings().Count;

                Assert.IsTrue(itemsCountBeforeDeletion == itemsCountAfterDeletion + 1);
            }
        }
    }
}
