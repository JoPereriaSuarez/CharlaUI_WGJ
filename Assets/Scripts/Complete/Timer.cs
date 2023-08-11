using System;

namespace WGJ.Complete
{
	public class Timer
	{
		public readonly float value;
		public float CurrentTime { get; private set; }
		public readonly Action onFinished;
		public bool IsDone { get; private set; }
		
		public Timer(float value, Action onFinished)
		{
			if (value <= 0)
				throw new ArgumentException($"Cannot create timer with no time entered value = {value}");
			this.value = value;
			this.onFinished = onFinished;
			CurrentTime = value;
		}

		public void Tick(float delta)
		{
			if(IsDone || delta < 0)
				return;

			CurrentTime -= delta;
			if(CurrentTime <= 0)
				Trigger();
			
		}

		public void Reset()
		{
			IsDone = false;
			CurrentTime = value;
		}

		public void Trigger()
		{
			IsDone = true;
			onFinished?.Invoke();
		}
	}
}