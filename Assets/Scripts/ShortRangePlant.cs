using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{

    public class ShortRangePlant : MonoBehaviour
    {

        public float waterBar = 100f;
        public float attackTimer = 0;
        public float maxTime = 5f;
        public float damage = 10f;
        public float waterLoss = 1f;


        public enum GrowthState { Seed, Sapling, Plant };
        public GrowthState state = GrowthState.Seed;
        public float lifeTime = 0f;
        public float saplingAge = 5f;
        public float plantAge = 5f;

        void Update()
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            waterBar -= waterLoss * Time.deltaTime; // UI code is not for me 
            if (waterBar <= 0)
            {
                Wilt();
            }
            GrowPlant();
        }

        void GrowPlant()
        {
            if (state == GrowthState.Seed)
            {
                lifeTime += Time.deltaTime;
                if (lifeTime >= saplingAge)
                {
                    state = GrowthState.Sapling;
                    //animation 
                }
            }
            else if (state == GrowthState.Sapling)
            {
                lifeTime += Time.deltaTime;
                if (lifeTime >= plantAge)
                {
                    state = GrowthState.Plant;
                    //animation
                }
            }
        }

        void AreaDamageEnemies(Vector3 location, float radius, float damage)
        {
            Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
            foreach (Collider col in objectsInRange)
            {
                EnemyHP enemy = col.GetComponent<EnemyHP>(); //need enemies to have an Enemy script attached
                if (enemy != null)
                {
                    // linear falloff of effect
                    float proximity = (location - enemy.transform.position).magnitude;
                    float effect = 1 - (proximity / radius);


                    enemy.TakeDamage(damage * effect);
                }
            }

        }

        private void Wilt()
        {
            //animation stuff if necessary
            Destroy(gameObject);
        }

        public void FillWater(float vol) //will the player call this method?
        {
            waterBar += vol;
        }

    }
}