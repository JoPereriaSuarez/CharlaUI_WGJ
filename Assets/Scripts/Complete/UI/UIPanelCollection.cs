using System;
using System.Linq;
using UnityEngine;

namespace WGJ.Complete
{
	[CreateAssetMenu(fileName = nameof(UIPanelCollection), menuName = "UI/Panel Collection")]
	public class UIPanelCollection : ScriptableObject
	{
		[Serializable]
		private record UIPanelData
		{
			public PANEL_TYPE panelType;
			public UIPanel prefab;
		}

		[SerializeField] private UIPanelData[] panels;

		public UIPanel GetPanel(PANEL_TYPE panelType) => panels.FirstOrDefault(panel => panel.panelType == panelType)?.prefab;
	}
}