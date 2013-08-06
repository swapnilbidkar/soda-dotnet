﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soda2Consumer;

namespace UnitTests.integration
{
    [TestClass]
    public class DatasetIntegrationTest
    {
        public static Soda2Client noAuthClient = new Soda2Client();
        public static Dataset<Row> dataset = noAuthClient.getDatasetInfo<Row>("opendata.test-socrata.com", "qrqr-xi46");

        [TestMethod]
        public void noopIntegrationTest()
        {
        }

        [TestMethod]
        public void datasetInfoTest() 
        {   
            Assert.IsNotNull(dataset.columns);
            Assert.IsNotNull(dataset.name);
        }

        [TestMethod]
        public void simpleQueryTest()
        {
            var qr = dataset.query("select *");
            Assert.IsNotNull(qr.rows);
            Assert.IsTrue(qr.rows.Length == 1000);
        }

        [TestMethod]
        public void complexQueryTest()
        {
            var qr = dataset.query("select id, description, location_description where primary_type = 'ASSAULT' limit 5 offset 5");
            Assert.IsNotNull(qr.rows);
            Assert.IsTrue(qr.rows.Length == 5);
        }
    }
}
