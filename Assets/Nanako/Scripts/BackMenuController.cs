using GoogleARCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Nanako
{
    /// <summary>
    /// ARCore异常和返回菜单控制
    /// </summary>
    public class BackMenuController : MonoBehaviour
    {
        /// <summary>
        /// 异常显示文本
        /// </summary>
        private Text text;
        /// <summary>
        /// 异常显示背景
        /// </summary>
        private GameObject panel;

        void Start()
        {
            text = GetComponentInChildren<Text>();
            panel = transform.GetChild(0).gameObject;
            panel.SetActive(false);
        }

        void Update()
        {
            //按退出按钮返回菜单
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }

            //处于追踪状态不会进入睡眠模式
            if (Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = 15;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            //显示异常后不继续操作
            if (panel.activeSelf)
            {
                return;
            }
            //如果有异常则显示，并于1秒后返回菜单
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            {
                panel.SetActive(true);
                text.text = "Camera permission is needed.";
                Invoke("BackMenu", 1f);
            }
            else if (Session.Status.IsError())
            {
                panel.SetActive(true);
                text.text = "ARCore encountered a problem connecting.";
                Invoke("BackMenu", 1f);
            }
        }
        /// <summary>
        /// 返回菜单场景
        /// </summary>
        private void BackMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }

}