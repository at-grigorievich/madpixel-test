using System;
using System.Collections;
using UnityEngine;

namespace ATG.MVC
{
    public sealed class ChestView : View, IDisposable
    {
        [SerializeField] private ChestModel model;
        [SerializeField] private ParticleSystem pokePunchVFX;

        private float _currentAnimationTime;
        private IEnumerator _animation;

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            Dispose();
        }

        public void Dispose()
        {
            if (_animation != null)
            {
                StopCoroutine(_animation);
            }
            _animation = null;

            _currentAnimationTime = 0f;

            pokePunchVFX.Stop();
        }

        public void AnimatePokePunch(Action callback)
        {
            Dispose();

            _animation = PokePunchAnimation(callback);
            StartCoroutine(_animation);
        }

        private IEnumerator PokePunchAnimation(Action callback)
        {
            while(_currentAnimationTime <  1f)
            {
                float scaleCoeff = model.PokeScaleSize.Evaluate(_currentAnimationTime);

                Vector3 nextScale = Vector3.one * scaleCoeff;
                
                transform.localScale = nextScale;

                _currentAnimationTime += model.PokeSpeed * Time.deltaTime;

                yield return null;
            }

            if(model.UseVFXOnFinish == true)
            {
                pokePunchVFX.Play();
            }  

            callback?.Invoke();

            _animation = null;
        }
    }
}