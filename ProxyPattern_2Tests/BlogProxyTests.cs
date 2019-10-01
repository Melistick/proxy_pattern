using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyPattern_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ProxyPattern_2.Tests
{
    [TestClass()]
    public class ProxyPatternTests

    {
        [TestMethod()]
        public void Authenticate_PasswordIncorrect_NotAuthenticated()
        {
            //Arange
            BlogProxy proxy = new BlogProxy();
            //Act           
            bool result = proxy.Authenticate("foutwachtwoord");
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Authenticate_PasswordCorrect_Authenticated()
        {
            //Arange
            BlogProxy proxy = new BlogProxy();
            //Act
            bool result = proxy.Authenticate("donderdag");
            //Assert
            Assert.IsTrue(result);
        }
    }
}