using System.Collections.Generic;
using UnityEngine;

namespace WGJ.Complete
{
     public class UIController : MonoBehaviour, IUIController
     {
         public delegate bool PanelDisplayedDelegate(PANEL_TYPE type, Canvas canvas, bool result);
         public static event PanelDisplayedDelegate OnPanelDisplayed;

         private static IUIController instance;
         public static IUIController Instance => instance ??= FindFirstObjectByType<UIController>();

         [SerializeField] private UIPanelCollection panelCollection;
         [SerializeField] private Canvas gameplayCanvas;
         [SerializeField] private Canvas settingsCanvas;

         private readonly List<UIPanel> panels = new();

         public void HidePanel(PANEL_TYPE type)
         {
             UIPanel panel = GetPanel(type);
             if (panel == null)
                 return;
             
             panel.Hide();
         }

         public bool DisplayPanelSettings(PANEL_TYPE panelType, params object[] args) =>
             DisplayPanel(panelType, settingsCanvas, args);
         public bool DisplayPanelGameplay(PANEL_TYPE panelType, params object[] args) => 
             DisplayPanel(panelType, gameplayCanvas, args);

         private bool DisplayPanel(PANEL_TYPE panelType, Canvas parent, params object[] args)
         {
             bool result = true; 
             UIPanel panel = GetPanel(panelType);
             if (panel == null)
             {
                 UIPanel prefab = panelCollection.GetPanel(panelType);
                 if (prefab == null)
                 {
                     Debug.LogError($"[ERROR] Cannot find prefab on {panelCollection.name} of type {panelType}");
                     result = false;
                 }
                 else
                 {
                     panel = Instantiate(prefab, parent.transform);
                     panels.Add(panel);
                 }
             }

                    
             if(result)
                 panel.Display(args);

             OnPanelDisplayed?.Invoke(panelType, parent, result);
             return result;
         }

         private UIPanel GetPanel(PANEL_TYPE panelType)
         {
             for (int i = 0; i < panels.Count; i++)
             {
                 if (panels[i].Type != panelType)
                     continue;

                 return panels[i];
             }

             return null;
         }
     }
}


