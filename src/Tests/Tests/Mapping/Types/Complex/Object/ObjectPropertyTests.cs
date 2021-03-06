﻿using System;
using Nest;
using Tests.Core.ManagedElasticsearch.Clusters;
using Tests.Domain;
using Tests.Framework.Integration;

namespace Tests.Mapping.Types.Core.Object
{
	public class ObjectPropertyTests : PropertyTestsBase
	{
		public ObjectPropertyTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override object ExpectJson => new
		{
			properties = new
			{
				leadDeveloper = new
				{
					type = "object",
					dynamic = true,
					enabled = true,
					properties = new
					{
						ipAddress = new
						{
							type = "ip"
						}
					}
				}
			}
		};

		protected override Func<PropertiesDescriptor<Project>, IPromise<IProperties>> FluentProperties => f => f
			.Object<Developer>(n => n
				.Name(p => p.LeadDeveloper)
				.Dynamic(true)
				.Enabled()
				.Properties(pps => pps
					.Ip(i => i
						.Name(p => p.IpAddress)
					)
				)
			);

		protected override IProperties InitializerProperties => new Properties
		{
			{
				"leadDeveloper", new ObjectProperty
				{
					Dynamic = true,
					Enabled = true,
					Properties = new Properties
					{
						{ "ipAddress", new IpProperty() }
					}
				}
			}
		};
	}
}
