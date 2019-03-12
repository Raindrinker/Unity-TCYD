using Boo.Lang;
using UnityEngine;

namespace System
{
    public class AnimationManager : MonoBehaviour
    {
        private List<Effect> effects = new List<Effect>();

        private float delay = 0.1f;
        private float timer;

        public void addEffect(Effect e)
        {
            effects.Add(e);
        }

        public void Update()
        {
            if (timer <= 0 && effects.Count > 0)
            {
                Debug.Log("EFFECT");
                effects[0].execute();
                effects.RemoveAt(0);
                timer = delay;
            }
            else
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        
    }
}