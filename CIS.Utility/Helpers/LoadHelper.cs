using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace CIS.Utility
{
    /// <summary>
    /// 加载器
    /// </summary>
    public class LoadHelper
    {
        /// <summary>
        /// 进程状态
        /// </summary>
        public enum ProcessState
        {
            /// <summary>
            /// 未知
            /// </summary>
            UnKnow
                ,
            /// <summary>
            /// 运行中
            /// </summary>
            Running
            ,
            /// <summary>
            /// 已完成
            /// </summary>
            Compeleted
            , 
            /// <summary>
            /// 错误
            /// </summary>
            Error
        }

        private const string LOADING_UI_KEY = "LOADING_UI";

        private static Hashtable prcoessStateSelector = new Hashtable();
        /// <summary>
        /// 获取指定元的进度状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ProcessState GetProcessState(object obj)
        {
            if (obj == null)
                return ProcessState.UnKnow;
            if (prcoessStateSelector.ContainsKey(obj))
                return (ProcessState) prcoessStateSelector[obj];
            return ProcessState.UnKnow;
        }
        /// <summary>
        /// 设置进程状态
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="processState"></param>
        private static void SetProcessState(object obj,ProcessState processState)
        {
            if (prcoessStateSelector.ContainsKey(obj))
                prcoessStateSelector[obj] = processState;
            else
                prcoessStateSelector.Add(obj, processState);
        }
        /// <summary>
        /// 移除状态元
        /// </summary>
        /// <param name="obj"></param>
        public static void Remove(object obj)
        {
            prcoessStateSelector.Remove(obj);
        }
        /// <summary>
        /// 在指定容器中显示加载动画UI
        /// </summary>
        /// <param name="container"></param>
        public static void ShowLoadingUI(Control container)
        {
            PictureBox picLoading = null;
            if (container.Controls.IndexOfKey(LOADING_UI_KEY) == -1)
            {
                //设置加载动画信息
                picLoading = new PictureBox();
                picLoading.Name = LOADING_UI_KEY;
                picLoading.BackColor = Color.FromArgb(120, Color.Gray);
                picLoading.SizeMode = PictureBoxSizeMode.CenterImage;
                picLoading.Image = Properties.Resources.加载动画;
                container.Controls.Add(picLoading);
                picLoading.Dock = DockStyle.Fill;
            }
            picLoading = container.Controls[LOADING_UI_KEY] as PictureBox;
            picLoading.BringToFront();
            picLoading.Visible = true;
        }
        /// <summary>
        /// 隐藏指定容器的加载动画UI
        /// </summary>
        public static void HiddenLoadingUI(Control container)
        {
            if (container.Controls.IndexOfKey(LOADING_UI_KEY) == -1)
                return;
            if (container.InvokeRequired)
            {
                container.Invoke((MethodInvoker)delegate
                {
                    container.Controls.RemoveByKey(LOADING_UI_KEY);
                });
            }
            else
                container.Controls.RemoveByKey(LOADING_UI_KEY);

        }
        /// <summary>
        /// 回调加载数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asyncResult"></param>
        private static void LoadDataCallback<T>(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
                return;
            dynamic obj = asyncResult.AsyncState;
            Func<T> getData = obj.Get;
            Action<T> refreshUI = obj.Set;
            Control container = obj.Container;
            //获取数据
            T data = getData.EndInvoke(asyncResult);
            //防止数据
            //if (!container.IsHandleCreated || container.IsDisposed)
            if (container.IsDisposed || !container.IsHandleCreated)
                return;
            //界面填充数据及隐藏加载动画UI
            if (container.InvokeRequired)
            {
                try
                {
                    container.Invoke((MethodInvoker)delegate
                    {
                        refreshUI(data);
                        HiddenLoadingUI(container);
                    });
                }
                catch { }
            }
            else
            {
                refreshUI(data);
                HiddenLoadingUI(container);
            }
        }
        /// <summary>
        /// 在指定控件容器内异步加载数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="container">控件容器 用于显示加载动画的地方</param>
        /// <param name="getData">获取数据的方法 里面的操作与界面无关</param>
        /// <param name="refreshUI">通过获取数据更新界面的方法</param>
        public static void LoadAsync<T>(Control container, Func<T> getData, Action<T> refreshUI)
        {
            if(container==null)
                throw new ArgumentNullException("container");
            if (getData == null)
                throw new ArgumentNullException("getData");
            //显示加载动画
            ShowLoadingUI(container);
            //异步回调加载
            getData.BeginInvoke(LoadDataCallback<T>, new { Get = getData, Set = refreshUI, Container = container });
        }
        /// <summary>
        /// 回调加载数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asyncResult"></param>
        private static void LoadDataWithStateCallback<T>(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
                return;
            dynamic obj = asyncResult.AsyncState;
            Func<T> getData = obj.Get;
            Action<T> refreshUI = obj.Set;
            Object o = obj.Obj;
            Control container = obj.Container;
            T data = default(T);
            try
            {
                //获取数据
                data = getData.EndInvoke(asyncResult);
            }
            catch
            {
                SetProcessState(o, ProcessState.Error);
                if (!container.IsHandleCreated || container.IsDisposed)
                    return;
                HiddenLoadingUI(container);
                return;
            }
            //防止数据
            if (!container.IsHandleCreated || container.IsDisposed)
                return;
            //界面填充数据及隐藏加载动画UI
            if (container.InvokeRequired)
            {
                container.Invoke((MethodInvoker)delegate
                {
                    refreshUI(data);
                    HiddenLoadingUI(container);
                });
            }
            else
            {
                refreshUI(data);
                HiddenLoadingUI(container);
            }
            SetProcessState(o, ProcessState.Compeleted);
        }
        /// <summary>
        /// 在指定控件容器内异步加载数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="container">控件容器 用于显示加载动画的地方</param>
        /// <param name="getData">获取数据的方法 里面的操作与界面无关</param>
        /// <param name="refreshUI">通过获取数据更新界面的方法</param>
        /// <param name="obj">状态元 用于跟踪进度状态的对象</param>
        public static void LoadAsync<T>(Control container, Func<T> getData, Action<T> refreshUI,object obj)
        {
            if (obj == null)
            {
                LoadAsync<T>(container, getData, refreshUI);
                return;
            }
            if (container == null)
                throw new ArgumentNullException("container");
            if (getData == null)
                throw new ArgumentNullException("getData");
            var process_state = GetProcessState(obj);
            if (process_state == ProcessState.Running)
                return;
            SetProcessState(obj, ProcessState.Running);
            //显示加载动画
            ShowLoadingUI(container);
            
            //异步回调加载
            getData.BeginInvoke(LoadDataWithStateCallback<T>, new { Get = getData, Set = refreshUI, Container = container, Obj = obj });
         
        }

    }
}
