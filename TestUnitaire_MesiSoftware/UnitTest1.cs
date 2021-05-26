using FluentAssertions;
using Mesi_Software.Entity;
using Mesi_Software.Utils;
using Mesi_Software.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestUnitaire_MesiSoftware
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2,2,1)]
        [TestCase(3,3,1)]
        [TestCase(4,3,2)]
        [TestCase(5,3,2)]
        [TestCase(6,3,2)]
        [TestCase(7,3,3)]
        [TestCase(8,3,3)]
        [TestCase(9,3,3)]
        [TestCase(10,3,4)]
        [TestCase(11,3,4)]
        [TestCase(12,3,4)]
        [TestCase(13,3,5)]
        [TestCase(14,3,5)]
        [TestCase(15,3,5)]

        public void TestCalculNbRowColumn(int nbReponse,int NbColonne,int NbLigne)
        {
            //GIVEN
            modeSoloViewModel msvm = new modeSoloViewModel();

            //WHEN
            (int colonnes,int lignes) result = msvm.CalculNombreColumnRow(nbReponse);

            //THEN
            result.colonnes.Should().Be(NbColonne);
            result.lignes.Should().Be(NbLigne);

        }        
        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void TestCalculNbRowColumnZero(int NbReponse)
        {
            //GIVEN
            modeSoloViewModel msvm = new modeSoloViewModel();

            //WHEN
            Action act = () => { msvm.CalculNombreColumnRow(NbReponse); };

            //THEN
            act.Should().Throw<Exceptions.QuestionsException>().WithMessage(Constantes.Message.ERROR_MESSAGE_NB_REPONSES_INCORRECT);
        }


    }
}