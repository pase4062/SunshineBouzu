using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

namespace Core
{
    public class TitleController : MonoBehaviour
    {
        private void Awake()
        {
            InitializeGameStart();
        }

        private void Update()
        {
            if (is_start_)
            {
                FadeOutGameStart();

                Color color = fade_renderer_.color;
                if (color.a < 1.0f)
                {
                    color.a += 0.01f;
                    fade_renderer_.color = color;
                }
                else
                {
                    // シーン遷移またはゲーム画面に移行
                    SceneManager.LoadScene("YanagidaScene");
                }
            }
            else
            {
                if (sun_transform_.position.x > -5.0f)
                {
                    sun_transform_.Translate(-0.05f, 0.0f, 0.0f);
                }
                else
                {
                    if (is_ready_)
                    {
                        if (is_game_start_fade_)
                        {
                            FadeOutGameStart();
                        }
                        else
                        {
                            FadeInGameStart();
                        }

                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("A_Button"))  // キー入力
                        {
                            is_start_ = true;
                        }
                    }
                    else
                    {
                        CheckPlayerFlipX();

                        if (left_transform_.localPosition.x > -15.0f)
                        {
                            TranslateShadowBlockLeft();
                            TranslateShadowBlockRight();
                        }
                        else
                        {
                            is_ready_ = true;
                        }
                    }
                }
            }
        }

        private void InitializeGameStart()
        {
            var color = game_start_text_.color;
            color.a = 0.0f;
            game_start_text_.color = color;
        }

        private void CheckPlayerFlipX()
        {
            if (player_renderer_.flipX)
            {
                player_renderer_.flipX = false;
            }
        }

        private void TranslateShadowBlockLeft()
        {
            left_transform_.Translate(-0.05f, 0.0f, 0.0f);

            var left_position = left_transform_.localPosition;
            if (left_position.x < -15.0f)
            {
                left_position.x = -15.0f;
                left_transform_.localPosition = left_position;
            }
        }

        private void TranslateShadowBlockRight()
        {
            right_transform_.Translate(0.3f, 0.0f, 0.0f);

            var right_position = right_transform_.localPosition;
            if (right_position.x > 25.0f)
            {
                right_position.x = 25.0f;
                right_transform_.localPosition = right_position;
            }
        }

        private void FadeInGameStart()
        {
            var color = game_start_text_.color;
            color.a += 0.01f;
            game_start_text_.color = color;

            if (color.a >= 1.0f)
            {
                is_game_start_fade_ = true;
            }
        }

        private void FadeOutGameStart()
        {
            var color = game_start_text_.color;
            color.a -= 0.01f;
            game_start_text_.color = color;

            if (color.a <= 0.0f)
            {
                is_game_start_fade_ = false;
            }
        }

        [SerializeField]
        private Transform sun_transform_ = null;

        // -13 -> -15 = -2 0.1f
        [SerializeField]
        private Transform left_transform_ = null;

        // 13 -> 25 = +12 0.6f
        [SerializeField]
        private Transform right_transform_ = null;

        [SerializeField]
        private SpriteRenderer player_renderer_ = null;

        [SerializeField]
        private Text game_start_text_ = null;

        [SerializeField]
        private SpriteRenderer fade_renderer_ = null;

        private bool is_start_ = false;

        private bool is_ready_ = false;

        private bool is_game_start_fade_ = false;
    }
}