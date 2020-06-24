using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGoal : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    GameObject player;

    ParticleSystem GoalPositionParticle;

    ParticleSystem ClearEffectParticle;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        GoalPositionParticle = GameObject.Find("GoalPosition").GetComponent<ParticleSystem>();
        ClearEffectParticle = GameObject.Find("ClearEffect").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalPositionParticle.isStopped)
        {
            // ゴール時キー入力で遷移
            if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("A_Button"))
            {
                SceneManager.LoadScene("TitleScene");
            }

            if (ClearEffectParticle.isStopped)
            {

                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GoalPositionParticle.isPlaying)
            {
                audioSource.PlayOneShot(audioClip[0]);  // ステージクリアSE再生
            }


            GoalPositionParticle.Stop();
            ClearEffectParticle.Play();
        }
    }


}
