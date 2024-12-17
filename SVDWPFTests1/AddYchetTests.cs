using Microsoft.VisualStudio.TestTools.UnitTesting;
using SVDWPF.AppData;
using SVDWPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVDWPF.Pages.Tests
{
    [TestClass()]
    public class AddYchetTests
    {
        [TestMethod()]
        public void CheckAccountingTest()
        {
            Ychetn inf = new Ychetn { nomer_licevogo_Scheta = 1, nomer_zapisi = 1, Mesyac = "Март", Tariff = "Эконом", kolvo_kilovatt = 122 };
            bool expected = true;
            bool actual = AddYchet.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckInformationTypeTest()
        {
            Ychetn inf = new Ychetn { nomer_licevogo_Scheta = 2, nomer_zapisi = 2, Mesyac = "", Tariff = "", kolvo_kilovatt = 123 };
            bool expected = false;
            bool actual = AddYchet.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckInformationTypeTest2()
        {
            Ychetn inf = new Ychetn { nomer_licevogo_Scheta = 3, nomer_zapisi = 3, Mesyac = "Апрель", Tariff = "Стандарт", kolvo_kilovatt = 124 };
            bool expected = false;
            bool actual = AddYchet.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckInformationTypeTest3()
        {
            Ychetn inf = new Ychetn { nomer_licevogo_Scheta = 4, nomer_zapisi = 4, Mesyac = "Май", Tariff = "Премиум", kolvo_kilovatt = 125 };
            bool expected = false;
            bool actual = AddYchet.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckInformationTypeTest4()
        {
            Ychetn inf = new Ychetn { nomer_licevogo_Scheta = 5, nomer_zapisi = 5, Mesyac = "Июнь", Tariff = "Стандарт", kolvo_kilovatt = 126 };
            bool expected = false;
            bool actual = AddYchet.CheckAccounting(inf);
            Assert.AreEqual(expected, actual);
        }
    }
} 