using UnityEngine;

namespace System
{
    public class Effect : MonoBehaviour {
    
        void Start () {
            
            GameObject.Find("AnimationManager").GetComponent<AnimationManager>().addEffect(this);
        }

        public void execute()
        {
            GetComponent<Animator>().SetBool("start", true);
            Destroy (gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}