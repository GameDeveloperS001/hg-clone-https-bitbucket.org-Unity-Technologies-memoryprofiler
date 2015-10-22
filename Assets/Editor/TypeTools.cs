using System;
using UnityEditor.MemoryProfiler;
using System.Collections.Generic;

namespace MemoryProfilerWindow
{
	static class TypeTools
	{
		static public IEnumerable<FieldDescription> AllFieldsOf (TypeDescription typeDescription, TypeDescription[] typeDescriptions)
		{
			if (typeDescription.isArray)
				yield break;
			
			if (typeDescription.baseOrElementTypeIndex != -1) {
				var baseTypeDescription = typeDescriptions [typeDescription.baseOrElementTypeIndex];
				foreach(var field in AllFieldsOf(baseTypeDescription, typeDescriptions))
					yield return field;
			}

			foreach(var field in typeDescription.fields)
				yield return field;
		}
	}
}

