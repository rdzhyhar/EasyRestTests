using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tests
{
    public class SignInTest : BaseTest
    {
        [Test]
        public void NegativeEmailAndPassword()
        {
            BasePageObject basePageObject = new BasePageObject(driver);
            basePageObject.ClickSignIn();
            Thread.Sleep(3000);
            SignInPageObject signInPageObject = new SignInPageObject(driver);

            signInPageObject.SendTextToEmail("negative_email@test.com");
            signInPageObject.SendTextToPassword("00000000");
            Thread.Sleep(2000);
            signInPageObject.ClickSubmit();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetErrorMessageEmailOrPasswordIsNotValid();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText,
                            actualErrorMessageText,
                            $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
            signInPageObject.ClickReturnBackButton();
           

        }
    }
}
