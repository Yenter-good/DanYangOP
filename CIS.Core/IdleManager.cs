using System;
using System.Collections.Generic;

namespace CIS.Core
{
    /// <summary>
    /// 闲置管理器
    /// </summary>
    public class IdleManager
    {
        private class IdleJob
        {
            private WeakReference warper = null;
            private Action _Action = null;
            private int _IdleTime = -1;
            private bool _Excuted = false;
            /// <summary>
            /// 是否已执行
            /// </summary>
            public bool Excuted
            {
                get { return _Excuted; }
                set { _Excuted = value; }
            }
            /// <summary>
            /// 闲置时间 单位毫秒
            /// </summary>
            public int IdleTime
            {
                get { return _IdleTime; }
            }
            /// <summary>
            /// 执行的方法
            /// </summary>
            public Action Action
            {
                get { return _Action; }
            }
            
            public object Target
            {
                get { return warper.Target; }
            }

            public bool IsAlive
            {
                get { return warper.IsAlive; }
            }
            public IdleJob(object target, Action action, int idleTime)
            {
                warper = new WeakReference(target);
                _Action = action;
                _IdleTime = idleTime;
            }
        }
        private System.Windows.Forms.Timer timer = null;
        private List<IdleJob> jobs = null;



        public IdleManager()
        {
            jobs = new List<IdleJob>();
            timer.Interval = 200;
            timer.Tick += timer_Tick;


        }

        /// <summary>
        /// 一个引用对象只能设置一次
        /// </summary>
        /// <param name="target">对象</param>
        /// <param name="action">执行方法委托</param>
        /// <param name="idleTime">闲置时间 单位 分钟</param>
        public void Set(object target, Action action, int idleTime)
        {
            if (target == null || action == null) return;
            if (idleTime < 0) return;
            if (jobs.Exists(j => j.Target == target))
                return;
            var job = new IdleJob(target, action, idleTime * 60 *1000);
            jobs.Add(job);

            //如果定时器未运行 则 启动
            if (!timer.Enabled)
                timer.Start();
        }

        /// <summary>
        /// 清除无效数据
        /// </summary>
        private void ClearInvalidJobs()
        {
            jobs.RemoveAll(j =>
            {
                if (!j.IsAlive) return true;
                if (j.Target == null) return true;
                if (j.Target is System.Windows.Forms.Control)
                {
                    var ctrl = (j.Target as System.Windows.Forms.Control);
                    if (ctrl.IsDisposed)
                        return true;
                }
                return false;
            }

            );

            //如果不存在闲置任务则停用定时器
            if (jobs.Count == 0)
                timer.Stop();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //清除无效的数据
            ClearInvalidJobs();
            long idle = ControlLib.NativeMethods.GetLastInputTime();
            jobs.ForEach(j => {
                //闲置时间满足时 执行闲置任务 同时设置已执行状态
                if (j.IdleTime <= idle && !j.Excuted)
                {
                    j.Excuted = true;
                    j.Action();
                }
                //闲置时间未满足时 重置执行状态 等待下一次
                if (j.IdleTime > idle)
                    j.Excuted = false;
            });
        }
    }
}
