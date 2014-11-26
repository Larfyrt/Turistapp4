using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using testturistapp.Annotations;
using testturistapp.Model;
using testturistapp.Viewmodel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace testturistapp.Viewmodel.Tests
{
    [TestClass()]
    public class RatingHandlerTests
    {
        private RatingHandler _ratingHandler;
        public Kategori SelectedKategori { get; set; }

        [TestInitialize]
        public void Beforetest()
        {
            _ratingHandler = new RatingHandler();
            ObservableCollection<Rating> Vurderinger = new ObservableCollection<Rating>();
            Rating r1 = new Rating("","","");
            
        }
        
        [TestMethod()]
        public void CheckNameTest()
        {
            string navn = "";
            for (int i = 0; i < 16; i++)
            {
                navn = navn + "J";
            }

            string navn2 = "";
            for (int i = 0; i < 50; i++)
            {
                navn2 = navn2 + "a";
            }
            _ratingHandler.Name = navn;
            Assert.AreEqual(navn, _ratingHandler.Name);

            try
            {
                _ratingHandler.Name = navn2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Max 30 cifre", ex.Message);
            }
        }

        [TestMethod()]
        public void RatingHandlerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void opretRatingTest()
        {
            Rating r2 = new Rating("gaga","ggaa","gaag");
            SelectedKategori.Vurderinger.Add(r2);
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void sletRatingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckRatingTest()
        {
            string rating = "";
            for (int i = 0; i < 6; i++)
            {
                rating = rating + "A";
            }
            Assert.Fail();
        }
    }
}
