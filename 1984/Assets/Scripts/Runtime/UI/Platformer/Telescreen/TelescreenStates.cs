using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Enums;

namespace TeleScreen
{
    public class ReadyState : ITelescreen
    {
        private float curTime;
        private float targetTime;
        private Telescreen telescreen;

        public ReadyState(Telescreen telescreen)
        {
            this.telescreen = telescreen;
        }


        public void OnEnter()
        {
            Debug.Log("ReadyState OnEnter");
            curTime = 0f;
            targetTime = 2f;
        }

        public void OnExcute()
        {
            Debug.Log("ReadyState Excute");

            curTime += Time.deltaTime;

            if (curTime >= targetTime )
            {
                telescreen.ChangeState(Enums.TeleScreenType.On);
            }
            
            //if (!telescreen.isVisible)
            //{
            //    telescreen.ChangeState(Enums.TeleScreenType.Off);
            //}
        }

        public void OnExit()
        {
            Debug.Log("ReadyState OnExit");
        }
    }


    public class OnState : ITelescreen
    {
        private Telescreen telescreen;
        private PlayerMoveTracker playerMoveTracker;
        private float curTime;
        private float targetTime;
        public OnState(Telescreen telescreen)
        {
            this.telescreen = telescreen;
            playerMoveTracker = telescreen.playerMoveTracker;
        }
        public void OnEnter()
        {
            curTime = 0f;
            targetTime = 2f;
            Debug.Log("OnState OnEnter");
            playerMoveTracker.isTraces = true;
            //telescreen.ChangePlayerTrace(true);
        }

        public void OnExcute()
        {
            curTime += Time.deltaTime;

            Debug.Log("OnState Excute");
            if (curTime >= targetTime)
            {
                telescreen.ChangeState(Enums.TeleScreenType.Off);
            }
        }

        public void OnExit()
        {
            Debug.Log("OnState OnExit");
            playerMoveTracker.isTraces = false;
        }
    }


    public class OffState : ITelescreen
    {
        private Telescreen telescreen;
        private float curTime;
        private float targetTime;
        public OffState(Telescreen telescreen)
        {
            this.telescreen = telescreen;
        }
        public void OnEnter()
        {
            Debug.Log("OffState OnEnter");
            curTime = 0f;
            targetTime = Random.Range(3, 5);
            //telescreen.ChangePlayerTrace(false);
        }

        public void OnExcute()
        {
            Debug.Log("OffState Excute");

            curTime += Time.deltaTime;
            
            if (curTime >= targetTime)
            {
                telescreen.ChangeState(Enums.TeleScreenType.Ready);
            }
        }

        public void OnExit()
        {
            Debug.Log("OffState OnExit");
        }
    }
}
