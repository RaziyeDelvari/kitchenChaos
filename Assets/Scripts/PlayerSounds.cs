using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player Player;
    private float footStepTimer;
    private float footStepTimerMax = .1f;

    private void Awake()
    {
        Player = GetComponent<Player>();
    }

    private void Update()
    {
        footStepTimer -= Time.deltaTime;
        if (footStepTimer < 0f )
        {
            footStepTimer = footStepTimerMax;

            if (Player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootSteps(Player.transform.position, volume);

            }
        }
    }
}
