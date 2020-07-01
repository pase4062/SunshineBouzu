using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> audioClip = new List<AudioClip>();

    GameObject player;

    ParticleSystem GoalPositionParticle;

    ParticleSystem ClearEffectParticle;

    int SceneIndexNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        GoalPositionParticle = GameObject.Find("GoalPosition").GetComponent<ParticleSystem>();
        ClearEffectParticle = GameObject.Find("ClearEffect").GetComponent<ParticleSystem>();
        SceneIndexNum = SceneManager.GetActiveScene().buildIndex;   // 現在のシーン番号取得
        FadeManager.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(GoalPositionParticle.isStopped)
        {
            // ゴール時キー入力で遷移
            if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("A_Button"))
            {
                FadeManager.FadeOut(SceneIndexNum + 1);
                //SceneManager.LoadScene("Stage2");
            }

            if (ClearEffectParticle.isStopped)
            {

                FadeManager.FadeOut(SceneIndexNum + 1);
                //SceneManager.LoadScene("Stage2");
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
