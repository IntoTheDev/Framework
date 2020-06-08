﻿using UnityEngine;

namespace ToolBox.Utilities
{
	[System.Serializable]
	public struct RangeFloat
	{
		[SerializeField] private Vector2 possibleValue;

		public float Value => Random.Range(possibleValue.x, possibleValue.y);
	}
}
