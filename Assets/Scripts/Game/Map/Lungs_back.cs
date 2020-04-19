using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lungs_back : MonoBehaviour {

    public GameObject player;
    ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            if(transform.position.y < player.transform.position.y)
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.3f);
            else player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.3f);
            enter[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }
}

// source : https://docs.unity3d.com/2017.3/Documentation/Manual/PartSysTriggersModule.html