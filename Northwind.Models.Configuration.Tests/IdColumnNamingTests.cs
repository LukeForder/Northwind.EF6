using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Northwind.Models.Configuration.Tests
{
    public class IdColumnNamingTests
    {
        public class TestModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }


        [Fact]
        public void it_applies_id_convention_to_keys()
        {
            var modelBuilder = new DbModelBuilder();

            modelBuilder.Entity<TestModel>();

            modelBuilder.Conventions.Add(new Conventions.IdColumnNamingConvention());

            var providerInfo = new DbProviderInfo("System.Data.SqlClient", "2008");

            var compiledModel = modelBuilder.Build(providerInfo);


            Assert.Equal(
                "TestModelId",
                compiledModel
                    .StoreModel
                    .EntityTypes
                    .First(x => x.Name == "TestModel")
                    .KeyProperties
                    .First()
                    .Name);

        }
    }
}
