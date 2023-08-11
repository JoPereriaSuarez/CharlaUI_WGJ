using UnityEngine;

namespace WGJ.Complete
{
	public interface IUIController
	{
		void HidePanel(PANEL_TYPE type);
		bool DisplayPanelGameplay(PANEL_TYPE panelType, params object[] args);
         
	}
}