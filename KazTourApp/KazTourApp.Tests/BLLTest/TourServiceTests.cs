using KazTourApp.DAL;
using KazTourApp.Shared.ViewModels;
using KazTourApp.BLL;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KazTourApp.Shared.Models;

namespace KazTourApp.Tests.DLLTest
{
    [TestClass]
    public class TourServiceTests
    {
        public void Should_Find_ByCriteria()
        {
            // Arrange
            TourStorage storage = new TourStorage();
            storage.AddTour(new TourRecord
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
                ));
            storage.AddTour(new TourRecord
                (
                    2,
                    "Tour to USA, Virginia",
                    "USA",
                    "Virginia",
                    new DateTime[] { new DateTime(2018, 07, 11) },
                    new int[] { 11 },
                    new int[] { 5 },
                    8,
                    300000
                ));
            storage.AddTour(new TourRecord
                (
                    3,
                    "Tour to USA, Virginia",
                    "USA",
                    "Virginia",
                    new DateTime[] { new DateTime(2018, 07, 25) },
                    new int[] { 12 },
                    new int[] { 7 },
                    8,
                    350000
                ));

            TourService service = new TourService(storage);
            TourSearchRequest request = new TourSearchRequest("Japan", new DateTime(2018, 08, 10), 2, 3);

            // Act
            List<TourRecord> filtered = service.FilterByCriteria(request);

            // Assert
            Assert.IsTrue(filtered[0].City == "Kyoto");

        }
    }
}
