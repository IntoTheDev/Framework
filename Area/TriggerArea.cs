﻿using Sirenix.OdinInspector;
using ToolBox.Extensions;
using ToolBox.Modules;
using ToolBox.Tags;
using UnityEngine;

namespace ToolBox.Utilities
{
	[DisallowMultipleComponent, RequireComponent(typeof(Collider2D))]
	public abstract class TriggerArea : MonoBehaviour
	{
		[SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 1, Expanded = true, DraggableItems = false), FoldoutGroup("Data")] protected EventsData[] onEnter = null;

		[SerializeField, ReadOnly, FoldoutGroup("Debug")] protected int index = 0;

		[Button("Set Index"), FoldoutGroup("Debug")]
		public void SetIndex(int index) =>
			this.index = index;

		[System.Serializable]
		protected struct EventsData
		{
#if UNITY_EDITOR
			[SerializeField] private string editorName;
#endif

			[SerializeField, AssetSelector] private Tag[] tags;
			[SerializeField] private bool allTagsRequired;
			[SerializeReference] private ModulesContainer reactors;
			[SerializeReference] private ModulesContainer<GameObject> reactorsGeneric;

			public void Call(GameObject entity)
			{
				if (!entity.HasTags(tags, allTagsRequired))
					return;

				reactors.Process();
				reactorsGeneric.Process(entity);
			}
		}
	}
}
