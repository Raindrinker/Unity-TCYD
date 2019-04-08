using UnityEngine;

namespace System
{
    public class EffectTweenMove : Effect
    {
        private TweenVector tween;
        private Vector2 startPos, endPos;

        public void setTween(TweenVector tween)
        {
            this.tween = tween;
        }

        public void setMove(Vector2 startPos, Vector2 endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }
        
        public override void execute()
        {
            tween.startingVector = startPos;
            tween.endVector = endPos;
            tween.duration = delay;
            
            tween.Begin(); 
            Destroy(this);
        }
    }
}