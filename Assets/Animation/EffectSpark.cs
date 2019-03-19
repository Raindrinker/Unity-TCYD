using UnityEngine;

namespace System
{
    public class EffectSpark : Effect
    {
        public void Start()
        {
            gameObject.SetActive(false);
        }
        
        public override void execute()
        {
            gameObject.SetActive(true);
            GetComponent<Animator>().SetBool("start", true);
            Destroy (gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}