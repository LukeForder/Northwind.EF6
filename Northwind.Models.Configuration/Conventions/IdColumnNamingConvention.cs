using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.DependencyResolution;

namespace Northwind.Models.Configuration.Conventions
{
    public class IdColumnNamingConvention : IStoreModelConvention<EntityType>
    {
        private IPluralizationService _pluralizationService
           = DbConfiguration.DependencyResolver.GetService<IPluralizationService>();
        
        public void Apply(EntityType item, DbModel model)
        {
            var entitySet =
                model
                    .StoreModel
                    .Container
                    .EntitySets
                    .FirstOrDefault(x => x.ElementType == item);
            


            foreach (var key in item.KeyProperties)
            {
                var singularizedTableName = _pluralizationService.Singularize(entitySet.Table);

                key.Name = $"{singularizedTableName}{key.Name}";
            }

        }
    }
}
