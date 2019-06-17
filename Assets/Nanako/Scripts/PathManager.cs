using UnityEngine;
using UnityEngine.UI;

namespace Nanako
{
    /// <summary>
    /// 路径场景管理
    /// </summary>
    public class PathManager : MonoBehaviour
    {
        /// <summary>
        /// ARCore摄像头
        /// </summary>
        public Transform personCamera;
        /// <summary>
        /// 显示轨迹摄像头
        /// </summary>
        public Transform pathCamera;
        /// <summary>
        /// 滚动条
        /// </summary>
        private Slider slider;
        /// <summary>
        /// 轨迹线
        /// </summary>
        private LineRenderer line;
        /// <summary>
        /// 轨迹点
        /// </summary>
        private int pointNumber;

        void Start()
        {
            slider = FindObjectOfType<Slider>();
            line = FindObjectOfType<LineRenderer>();
            pointNumber = 0;
            //2秒后执行，每0.1秒执行一次
            InvokeRepeating("DrawPath", 2f, 0.1f);
        }

        void Update()
        {
            //保持轨迹摄像机在ARCore摄像机正上方
            pathCamera.position = new Vector3(
                personCamera.position.x, 
                pathCamera.position.y, 
                personCamera.position.z);
        }
        /// <summary>
        /// 设置轨迹摄像机高度，起到放大缩小轨迹线的效果
        /// </summary>
        public void ChangeHeight()
        {
            pathCamera.localPosition = new Vector3(
                pathCamera.localPosition.x, 
                slider.value, 
                pathCamera.localPosition.z);
        }
        /// <summary>
        /// 绘制轨迹
        /// </summary>
        private void DrawPath()
        {
            line.positionCount = pointNumber + 1;
            line.SetPosition(pointNumber, personCamera.position);
            pointNumber++;
        }
    }
}