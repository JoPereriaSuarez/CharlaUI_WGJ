using UnityEngine;
using UnityEngine.Events;

namespace WGJ.Complete
{
	[RequireComponent(typeof(Canvas))]
	public abstract class UIPanel : MonoBehaviour
	{
		protected Canvas Canvas { get; private set; }

		[SerializeField] private PANEL_TYPE type;
		public PANEL_TYPE Type => type;

		[SerializeField] protected UnityEvent onDisplayed;
		[SerializeField] protected UnityEvent onHidden;
		
		protected bool IsSetup { get; private set; }
		public bool IsDisplayed { get; private set; }
		protected virtual void Awake()
		{
			Canvas = GetComponent<Canvas>();
		}

		protected virtual void Setup(params object[] args)
		{
			if (IsSetup)
				return;
				
			IsSetup = true;
		}

		public virtual void Display(params object[] args)
		{
			if (IsDisplayed)
				return;
			
			Setup(args);

			Canvas.enabled = true;
			IsDisplayed = true;
			onDisplayed?.Invoke();
		}

		public virtual void Hide()
		{
			if (!IsSetup)
				return;
			
			Canvas.enabled = false;
			IsDisplayed = false;
			onHidden?.Invoke();
		}
        
	}
}