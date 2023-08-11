using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WGJ.Complete
{
	public class InformationPanel : UIPanel
	{
		[SerializeField] private TextMeshProUGUI text;
		[SerializeField] private Button closeButton;


		protected override void Awake()
		{
			base.Awake();
			closeButton.onClick.AddListener(()=> UIController.Instance.HidePanel(Type));
		}
		protected override void Setup(params object[] args)
		{
			base.Setup(args);
			if (args.Length < 2 || args[0] is not string || args[1] is not Action onClosed)
			{
				Debug.LogError($"Valid usage is Display(float), panel type {Type}");
				return;
			}
			
			onHidden?.AddListener(()=> onClosed?.Invoke());
		}

		public override void Display(params object[] args)
		{
			base.Display(args);
			if (args.Length < 2 || args[0] is not string content || args[1] is not Action)
			{
				Debug.LogError($"Valid usage is Display(float), panel type {Type}");
				return;
			}

			text.text = content;
		}
	}
}