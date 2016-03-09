using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Northwind.Models.Configuration.Tests
{
    public class ComplexTypeColumnNamingConventionTests
    {
        public class TestComplexType
        {
            public int IntProperty { get; set; }
            public string MyProperty { get; set; }
        }

        public class TestModel
        {
            public TestComplexType TestComplexType { get; set; }
            public int Id { get; set; }
        }

        [Fact]
        public void it_uses_property_names_as_column_names_for_complex_types()
        {
            var modelBuilder = new DbModelBuilder();

            modelBuilder.Entity<TestModel>();

            modelBuilder.Conventions.Remove(new ComplexTypeAttributeConvention());
            modelBuilder.Conventions.Add(new Conventions.CustomComplexTypeAttributeConvention());

            var providerInfo = new DbProviderInfo("System.Data.SqlClient", "2008");

            var compiledModel = modelBuilder.Build(providerInfo);

            Assert.True(
                compiledModel
                    .StoreModel
                    .EntityTypes
                     .First(x => x.Name == nameof(TestModel))
                    .Properties
                    .Any(x => x.Name == nameof(TestComplexType.IntProperty)));

            Assert.True(
               compiledModel
                    .StoreModel
                    .EntityTypes
                    .First(x => x.Name == nameof(TestModel))
                    .Properties
                    .Any(x => x.Name == nameof(TestComplexType.MyProperty)));
        }
    }
}
