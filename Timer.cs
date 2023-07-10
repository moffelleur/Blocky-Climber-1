    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;

    public class Timer : MonoBehaviour
    {
        [Header("Component")]
        public TextMeshProUGUI timerText;

        [Header("Timer Settings")]
        public float currentTime;
        public bool countDown;

        [Header("Limit Settings")]
        public bool hasLimit;
        public float timerLimit;

        [Header("Format Setting")]
        public bool hasFormat;
        public TimerFormats format;
        private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

        public Health playerHealth;
        public GameManagerScript gameManager;

        // Start is called before the first frame update
        void Start()
        {
            timeFormats.Add(TimerFormats.Whole, "0");
            timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
            timeFormats.Add(TimerFormats.HundrethDecimal, "0.00");
        }

        // Update is called once per frame
        void Update()
        {
            currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;

            if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
            {
                // Lose a life and respawn the player
                playerHealth.TakeDamage(1);
                gameManager.RespawnPlayer();

                // Restart the timer
                RestartTimer();
            }

            SetTimerText();
        }

        public void RestartTimer()
        {
            if (countDown)
            {
                currentTime = 30f;
            }
            else
            {
                currentTime = 0f;
            }

            timerText.color = Color.white;
            enabled = true;
        }


        private void SetTimerText()
        {
            timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
        }

        public enum TimerFormats
        {
            Whole,
            TenthDecimal,
            HundrethDecimal
        }
    }
