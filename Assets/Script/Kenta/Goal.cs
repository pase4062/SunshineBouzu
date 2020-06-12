using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    GameObject player;

    ParticleSystem GoalPositionParticle;

    ParticleSystem ClearEffectParticle;

    // Start is called before the first frame update
    void Start()
    {
        GoalPositionParticle = GameObject.Find("GoalPosition").GetComponent<ParticleSystem>();
        ClearEffectParticle = GameObject.Find("ClearEffect").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalPositionParticle.isStopped)
        {
            if (ClearEffectParticle.isStopped)
            {
                SceneManager.LoadScene("NextStage");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GoalPositionParticle.Stop();
            ClearEffectParticle.Play();
        }
    }

    
}
