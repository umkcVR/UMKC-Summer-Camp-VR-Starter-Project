using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public float EmitRate = 50.0f;
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        em.rateOverTime = EmitRate;

        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(2.0f, 100),
                new ParticleSystem.Burst(4.0f, 100)
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score == 5)
        {
            EmitRate = 99;
        }
    }
}
