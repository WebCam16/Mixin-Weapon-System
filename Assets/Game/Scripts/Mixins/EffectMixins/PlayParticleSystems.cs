using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystems : MixinBase {

    public List<ParticleSystem> particleSystems;

    public override void Action()
    {
        for (int i = 0; i < particleSystems.Count; i++)
        {
            particleSystems[i].Play();
        }
    }
}
