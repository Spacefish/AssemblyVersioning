﻿/*
	Copyright 2013 Imre Pühvel, AS Nortal
	
	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at

		http://www.apache.org/licenses/LICENSE-2.0

	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.

	This file is from project https://github.com/NortalLTD/AssemblyVersioning, Nortal.Utilities.AssemblyVersioning.Generators, file 'HumanReadableBuildInfoGenerator.cs'.
*/

using System;

namespace Nortal.Utilities.AssemblyVersioning.Generators
{
	public class HumanReadableBuildInfoGenerator : IVersionGenerator
	{
		#region IVersionGenerator Members

		public string GenerateVersionInfoFrom(VersionGenerationContext context)
		{
			if (context == null) { throw new ArgumentNullException("context"); }
			
			return String.Format("{0} (on UTC{1} by {2} at {3})",
				context.BuildConfiguration,
				DateTime.UtcNow.ToString("s"),
				Environment.UserName,
				Environment.MachineName);
		}

		#endregion
	}
}
