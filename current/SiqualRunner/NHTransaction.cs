using System;
using FluentNHibernate;
using SiqualRunner.Core;
using SiqualRunner.Core.Entities.mappings;
using SiqualRunner.Core.Repositories;
using SiqualRunner.Core.Services;
using StructureMap;
using StructureMap.Configuration.DSL;
using Undrtake.Infrastructure.Persistence;

namespace SiqualRunner
{
	public class NHTransaction : IDisposable
	{
		readonly IUnitOfWork _instance = ObjectFactory.GetInstance<IUnitOfWork>();
		public NHTransaction()
		{
			_instance.Initialize();
			_instance.BeginTransaction();
		}

		public void Dispose()
		{
			try
			{
				_instance.Commit();
			}
			catch
			{
				_instance.Rollback();
				throw;
			}
		}
	}

	public class Bootstrapper
	{
		public static void Start()
		{
			ObjectFactory.Initialize(a =>
			{
				a.AddRegistry(new MiscRegistry());
				a.AddRegistry(new RepositoryRegistry());
				a.AddRegistry(new ServicesRegistry());
			});

		}
	}

	public class ServicesRegistry : Registry
	{
		public ServicesRegistry()
		{
			ForRequestedType<IProjectService>().TheDefaultIsConcreteType<ProjectService>();
			ForRequestedType<ISiqualConnectionManager>().TheDefaultIsConcreteType<SiqualConnectionManager>();
			ForRequestedType<IFileSynchronizer>().TheDefaultIsConcreteType<FileSynchronizer>();
			ForRequestedType<IScriptRunner>().TheDefaultIsConcreteType<ScriptRunner>();
		}
	}

	public class RepositoryRegistry : Registry
	{
		public RepositoryRegistry()
		{
			ForRequestedType<IProjectRepository>().TheDefaultIsConcreteType<ProjectRepository>();
		}
	}

	public class MiscRegistry : Registry
	{
		public MiscRegistry()
		{
			ForRequestedType<INHUnitOfWork>().TheDefaultIsConcreteType<NHibernateUnitOfWork>().AsSingletons();

			ForRequestedType<ISessionSource>().AsSingletons()
				.TheDefault.Is.ConstructedBy(
					context => new SessionSource(new SQLRPersistenceModel())
				);
			ForRequestedType<IUnitOfWork>().TheDefault.Is.ConstructedBy(ctx => ctx.GetInstance<INHUnitOfWork>());
		}
	}
}