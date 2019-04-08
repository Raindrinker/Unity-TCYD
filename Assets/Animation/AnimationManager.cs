using Boo.Lang;
using UnityEngine;

namespace System
{
    public class AnimationManager : MonoBehaviour
    {
        public GameObject bonkPrefab;
        public GameObject slashPrefab;
        public GameObject blueBoltPrefab;
        
        private List<Effect> effects = new List<Effect>();

        private float timer;

        public void addEffect(Effect e)
        {
            effects.Add(e);
        }

        public void Update()
        {
            if (timer <= 0 && effects.Count > 0)
            {
                effects[0].execute();
                timer = effects[0].delay;
                effects.RemoveAt(0);
                
            }
            else
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
            }
        }

        public enum Spark
        {
            Bonk,
            Slash,
            BlueBolt
        }

        public EffectSpark SpawnSpark(Spark whichSpark, Vector2 pos)
        {
            EffectSpark spark = null;
            
            switch (whichSpark)
            {
                case Spark.Bonk:
                    spark = Instantiate(bonkPrefab).GetComponent<EffectSpark>();
                    break;
                case Spark.Slash:
                    spark = Instantiate(slashPrefab).GetComponent<EffectSpark>();
                    break;
                case Spark.BlueBolt:
                    spark = Instantiate(blueBoltPrefab).GetComponent<EffectSpark>();
                    break;
            }

            if (spark != null)
            {
                spark.transform.position = pos;
                addEffect(spark);
            }

            return spark;


        }
        
    }
}