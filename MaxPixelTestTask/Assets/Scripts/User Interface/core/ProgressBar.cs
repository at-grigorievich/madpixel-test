using UnityEngine;
using UnityEngine.UI;

namespace ATG.UserInterface
{
    [RequireComponent(typeof(RectTransform))]
    public class ProgressBar: MonoBehaviour
    {
        [SerializeField] private RectTransform progressRect;
        [SerializeField] private Text progressOutput;
        [SerializeField] private float maxWidth = 100f;

        public void UpdateProgress(float current, float max)
        {
            float rate = Mathf.Clamp01(current / max );

            float nextWidth = rate * maxWidth;

            Vector3 nextSizeDelta = new Vector2(nextWidth, progressRect.sizeDelta.y);
            progressRect.sizeDelta = nextSizeDelta;

            progressOutput.text = $"{Mathf.Round(current)}/{max}";
        }
    }
}