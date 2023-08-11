using System;
using UnityEngine;
using Random = System.Random;

namespace WGJ.Complete
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private int minTimerValue = 1;
		[SerializeField] private int maxTimerValue = 5;

		[SerializeField] private string[] phrases = 
		{
			"Welcome to Women Game jam",
			"This is an example text",
			"By the way I use linux",
		};

		private Random random;
		private void Start()
		{
			random = new();
			DisplayTimer(minTimerValue);
		}
		
		private void DisplayInformation(string content)
		{
			UIController.Instance.DisplayPanelGameplay(PANEL_TYPE.INFORMATION, content,
				new Action(() => DisplayTimer(GetRandom(minTimerValue, maxTimerValue))));
		}

		private void DisplayTimer(float timer)
		{
			UIController.Instance.DisplayPanelGameplay(PANEL_TYPE.TIMER, timer,
				new Action(()=> DisplayInformation(phrases[GetRandom(0, phrases.Length)])));
		}

		private int GetRandom(int min, int max) => random.Next(min, max);
	}
}