using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Core
{
    public class ShadowBlockController : MonoBehaviour
    {
        private bool operateFlag;   // 操作判定

        private void Awake()
        {
            mover_.Initialize();
        }

        private void Start()
        {
            operateFlag = false;
        }

        private void Update()
        {
            if (operateFlag)
            {


                if (input_.GetLeftKey() || Input.GetAxis("XboxRightAxisX") >= 0.7f)
                {
                    mover_.MoveLeft();
                }

                if (input_.GetRightKey() || Input.GetAxis("XboxRightAxisX") <= -0.7f)
                {
                    mover_.MoveRight();
                }

                if (input_.GetOpenKey())
                {
                    door_.Open();
                }

                if (input_.GetCloseKey())
                {
                    door_.Close();
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Cancel"))
            {
                if (operateFlag)
                {
                    operateFlag = false;
                }
                else
                {
                    operateFlag = true;
                }

            }
        }

        [SerializeField]
        private ShadowBlockMover mover_ = null;

        [SerializeField]
        private ShadowBlockInput input_ = null;

        [SerializeField]
        private ShadowBlockDoor door_ = null;
    }
}