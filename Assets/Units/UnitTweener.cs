using System;
using UnityEngine;

namespace Units.UnitLibrary
{
    public class UnitTweener : MonoBehaviour
    {
        private AnimationManager animationManager;
        
        private GameObject unitView;

        private Transform wrapper;

        private TweenTransforms tweenMove;

        public void Start()
        {
            animationManager = GameObject.Find("AnimationManager").GetComponent<AnimationManager>();
            
            wrapper = transform.Find("UnitTweenWrapper");
            
            tweenMove = gameObject.AddComponent<TweenTransforms>();
            tweenMove.myTweenType = TweenBase.playStyles.Single;
            tweenMove.TweenTransformProperty = TweenTransforms.TransformTypes.Position;
        }

        public void setUnitPrefab(GameObject unitViewPrefab)
        {
            unitView = Instantiate(unitViewPrefab, wrapper);
        }

        public void addTweenMove(Vector2 startPos, Vector2 endPos)
        {

            EffectTweenMove effectTween = gameObject.AddComponent<EffectTweenMove>();
            effectTween.setTween(tweenMove);
            effectTween.setMove(startPos, endPos);
            
            animationManager.addEffect(effectTween);
        }
        
        public void addTweenShake()
        {
            TweenSequence tweenSequence;
            
            tweenSequence = wrapper.GetComponent<TweenSequence>();
            
            EffectTweenSequence effectTween = gameObject.AddComponent<EffectTweenSequence>();
            effectTween.setTweenSequence(tweenSequence);
            
            animationManager.addEffect(effectTween);
        }

        public void addTweenDeath()
        {
            EffectDeath effectDeath = gameObject.AddComponent<EffectDeath>();
            animationManager.addEffect(effectDeath);
        }

        public void Death()
        {
            gameObject.SetActive(false);
        }

        public GameObject GetUnitView()
        {
            return unitView;
        }
        
        
    }
}