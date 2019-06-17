using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nanako
{
    /// <summary>
    /// 菜单场景控制
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        /// <summary>
        /// 退出应用
        /// </summary>
        public void Exit()
        {
            Application.Quit();
        }
    }
}