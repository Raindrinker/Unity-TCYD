namespace System
{
    public class EffectTweenSequence : Effect
    {
        private TweenSequence tweenSequence;

        public void setTweenSequence(TweenSequence tweenSequence)
        {
            this.tweenSequence = tweenSequence;
        }
        
        public override void execute()
        {
            tweenSequence.BeginSequence();
            Destroy(this);
        }
    }
}