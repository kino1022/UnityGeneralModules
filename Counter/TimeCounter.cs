using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GeneralModule.Counter.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GeneralModule.Counter {
    [Serializable]
    public class TimeCounter : ITimeCounter
    {

        [SerializeField, LabelText("カウント")]
        protected float m_count = Mathf.Min(0.0f, 0.0f);
        
        [SerializeField, LabelText("カウント中")]
        protected bool m_isProgress = false;

        protected CancellationTokenSource m_cts;

        public float Count => m_count;

        public bool IsProgress => m_isProgress;

        public TimeCounter()
        {
            m_cts = new();

            CancellationToken token = m_cts.Token;

            TimeCount().Forget();
        }

        public void Dispose()
        {
            m_cts.Cancel();
        }

        public void Start()
        {
            m_isProgress = true;
        }

        public void Stop()
        {
            m_isProgress = false;
        }

        public void Reset()
        {
            m_count = Mathf.Min(0.0f, 0.0f);
        }

        protected async UniTask TimeCount()
        {
            try
            {
                while (!m_cts.Token.IsCancellationRequested)
                {
                    if (IsProgress)
                    {
                        await UniTask.WaitForEndOfFrame();
                        m_count += Time.deltaTime;
                    }
                }
            }
            catch (OperationCanceledException)
            {

            }
        }
    }
}