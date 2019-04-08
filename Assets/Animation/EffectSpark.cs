using UnityEngine;

namespace System
{
    public class EffectSpark : Effect
    {
        private String sfx = "";
        
        public void Start()
        {
            gameObject.SetActive(false);
        }

        public void setSoundEffect(String sfx)
        {
            this.sfx = sfx;
        }
        
        public override void execute()
        {
            if(sfx != "") GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip(sfx);
            
            gameObject.SetActive(true);
            GetComponent<Animator>().SetBool("start", true);
            Destroy (gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}