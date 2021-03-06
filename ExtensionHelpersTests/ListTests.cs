﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ExtensionHelpers.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void CopyByValueListTest()
        {
            var newList = testList.CopyByValue();

            Assert.IsFalse(Object.ReferenceEquals(newList, testList));
            Assert.IsTrue(newList.Count == testList.Count);
        }

        [TestMethod]
        public void AddIfNotExistsListTestValueDoesExist()
        {
            testList.AddIfNotExists("Bob");
            Assert.IsTrue(testList.Count == 3);
        }

        [TestMethod]
        public void AddIfNotExistsListTestValueDoesNotExist()
        {
            testList.AddIfNotExists("John");
            Assert.IsTrue(testList.Count == 4);
            Assert.IsTrue(testList.Contains("John"));
        }

        [TestMethod]
        public void IsEqualTo_AreEqual()
        {
            Assert.IsTrue(testList.IsEqualTo(testList2));
            Assert.AreEqual(3, testList2.Count);
        }

        [TestMethod]
        public void IsEqualTo_NotEqual()
        {
            Assert.IsFalse(testList.IsEqualTo(testList3));
            Assert.AreEqual(4, testList3.Count);
        }

        [TestMethod]
        public void IsEqualTo_OriginalIsNull()
        {
            List<string> nullList = null;
            Assert.IsFalse(nullList.IsEqualTo(testList3));
        }

        [TestMethod]
        public void IsEqualTo_CompareIsNull()
        {
            List<string> nullList = null;
            Assert.IsFalse(testList2.IsEqualTo(nullList));
        }

        [TestMethod]
        public void IsEqualTo_BothIsNull()
        {
            List<string> nullList1 = null;
            List<string> nullList2 = null;

            Assert.IsTrue(nullList1.IsEqualTo(nullList2));
        }

        private List<string> testList = new List<string>
        {
            { "Bob" },
            { "Sally" },
            { "Joe" }
        };

        private List<string> testList2 = new List<string>
        {
            { "Joe" },
            { "Bob" },
            { "Sally" }
        };

        private List<string> testList3 = new List<string>
        {
            { "Joe" },
            { "Bob" },
            { "Sally" },
            { "Jane" }
        };
    }
}
