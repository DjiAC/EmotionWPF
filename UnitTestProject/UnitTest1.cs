﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emotion.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInit()
        {
            EmotionConnect test = new EmotionConnect();
        }

        [TestMethod]
        public void TestMethod1()
        {
            EmotionConnect test = new EmotionConnect();
            Assert.IsInstanceOfType(test.GetImageAsByteArray("path"), typeof(BinaryReader));
        }
    }
}