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
        }

        public void setUnitPrefab(GameObject unitViewPrefab)
        {
            unitView = Instantiate(unitViewPrefab, wrapper);
        }

        public void addTweenMove(Vector2 pos)
        {
            tweenMove.myTweenType = TweenBase.playStyles.Single;
            tweenMove.TweenTransformProperty = TweenTransforms.TransformTypes.LocalPosition;
            tweenMove.startingVector = transform.localPosition;
            tweenMove.endVector = pos;
            tweenMove.duration = 0.2f;

            EffectTween effectTween = gameObject.AddComponent<EffectTween>();
            effectTween.setTween(tweenMove);
            
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

        public GameObject GetUnitView()
        {
            return unitView;
        }
        
        
    }
}