using Units.UnitLibrary;

namespace System
{
    public class EffectDeath : Effect
    {

        public override void execute()
        {
            GetComponent<UnitTweener>().Death();
        }
    }
}