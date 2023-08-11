using System;
using TMPro;
using UnityEngine;

namespace WGJ.Complete
{
	public class TimerPanel : UIPanel
	{
		[SerializeField] private TextMeshProUGUI timerText;
		private Timer timer;

		public override void Display(params object[] args)
		{
			base.Display(args);
			if (args.Length < 2 || args[0] is not float timerValue || args[1] is not Action onFinished)
			{
				Debug.LogError($"Valid usage is Display(float), panel type {Type}");
				return;
			}

			timer = new(timerValue, ()=>
			{
				onFinished?.Invoke();
				Hide();
			});
		}

		public override void Hide()
		{
			base.Hide();
		}

		private void LateUpdate()
		{
			if (!IsDisplayed || timer == null)
				return;

			timer.Tick(Time.deltaTime);
			timerText.SetText(timer.CurrentTime.ToString("F1"));
		}
	}
}