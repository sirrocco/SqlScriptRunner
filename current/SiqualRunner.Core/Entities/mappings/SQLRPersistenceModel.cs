using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace SiqualRunner.Core.Entities.mappings
{
	public class SQLRPersistenceModel : PersistenceModel
	{
		public SQLRPersistenceModel()
		{
			ConventionDiscovery.Add(ConventionBuilder.Reference.Always(
			                        	p => p.ColumnName(p.Property.Name + "Id")));
			ConventionDiscovery.Add(ConventionBuilder.Id.Always(
			                        	p => p.ColumnName(p.EntityType.Name + "Id")));
			ConventionDiscovery.Add(ConventionBuilder.HasMany.Always(
			                        	p =>
			                        		{
			                        			if (p.KeyColumnNames.List().Count == 0)
			                        				p.KeyColumnNames.Add(p.EntityType.Name + "Id");
			                        		}));

			ConventionDiscovery.Add(ConventionBuilder.HasManyToMany.Always(
			                        	p =>
			                        		{
			                        			p.WithChildKeyColumn(p.ChildType.Name + "Id");
			                        			p.WithParentKeyColumn(p.EntityType.Name + "Id");
			                        		}));


			addMappingsFromThisAssembly();
		}

		public SetupConventionFinder<PersistenceModel> ConventionDiscovery
		{
			get { return new SetupConventionFinder<PersistenceModel>(this, ConventionFinder); }
		}




	}
}