using System;
using UnityEngine;

namespace ATG.Animation
{
	[RequireComponent(typeof(Animator))]
	public sealed class AnimatorCallbackService: MonoBehaviour, IAnimatorCallback
	{
		public const string CompleteDig = "FinishDigging";

		public event EventHandler<string> OnAnimatorReceived;
		
		public void AnimatorReceive(string obj)
		{
#if UNITY_EDITOR
			//Debug.Log("animator event received " + obj);
#endif
			if(enabled == false) return;
			if (OnAnimatorReceived == null) return;

			OnAnimatorReceived.Invoke(this,obj);
		}
	}
}

