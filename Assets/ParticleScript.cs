using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public float EmitRate = 50.0f, burstEmitRate = 100.0f, burstDuration = 0.5f, timeBetweenBursts = 3.0f;
    public ParticleSystem ps;

    void Start()
    {
        if(ps == null)
            ps = GetComponent<ParticleSystem>();
        //StartCoroutine("Burst");
    }

    public void EmitBurst()
    {
        StartCoroutine("Burst");
    }

    private IEnumerator Burst()
    {
        var em = ps.emission;
        em.enabled = true;

        em.rateOverTime = burstEmitRate;
        yield return new WaitForSeconds(burstDuration);

        em.rateOverTime = EmitRate;
        yield return new WaitForSeconds(timeBetweenBursts);
        //StartCoroutine("Burst");
    }
}
