using UnityEngine;

namespace System
{
    public class EffectTween : Effect
    {
        private TweenVector tween;

        public void setTween(TweenVector tween)
        {
            this.tween = tween;
        }
        
        public override void execute()
        {
            Debug.Log("Execute tween");
            
            Debug.Log("Tween end pos: " + tween.endVector);
            
            tween.Begin(); 
            Destroy(this);
        }
    }
}