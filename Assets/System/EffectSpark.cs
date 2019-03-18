using UnityEngine;

namespace System
{
    public class EffectSpark : Effect
    {      
        public override void execute()
        {
            GetComponent<Animator>().SetBool("start", true);
            Destroy (gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}