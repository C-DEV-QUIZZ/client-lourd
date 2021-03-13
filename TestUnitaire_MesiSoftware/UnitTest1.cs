using FluentAssertions;
using Mesi_Software.Utils;
using Mesi_Software.ViewModel;
using NUnit.Framework;
using System;

namespace TestUnitaire_MesiSoftware
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMethodGotoPseudoPageModeSolo()
        {
            AccueilViewModel avm = new AccueilViewModel();

            avm.GotoPseudoPage(Enums.modeJeu.solo);

            Assert.Pass();
        }        

        [Test]
        public void TestMethodGotoPseudoPageModeMulti()
        {
            //GIVEN
            AccueilViewModel avm = new AccueilViewModel();
            
            //WHEN
            Action act = () =>{avm.GotoPseudoPage(Enums.modeJeu.multi);};

            // THEN
            act.Should().ThrowExactly<Exception>().WithMessage("Le mode choisit est inexistant");
        }        
        [Test]
        public void TestMethodeQuitteApplication()
        {
            //GIVEN
            AccueilViewModel avm = new AccueilViewModel();

            //WHEN
            avm.QuitterApplication();

            // THEN
        }


    }
}