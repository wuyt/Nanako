using UnityEngine;
#if UNITY_EDITOR
using Input = GoogleARCore.InstantPreviewInput;
#endif

namespace Nanako
{
    /// <summary>
    /// 画线场景管理
    /// </summary>
    public class LineManager : MonoBehaviour
    {
        /// <summary>
        /// 坐标点
        /// </summary>
        public Transform point;
        /// <summary>
        /// 轨迹线
        /// </summary>
        private LineRenderer line;
        /// <summary>
        /// 坐标点数量
        /// </summary>
        private int pointNumber;

        /// <summary>
        /// 开始画线
        /// </summary>
        public void StartDraw()
        {
            //添加游戏对象
            GameObject go = new GameObject();
            //在游戏对象上添加LineRenderer组件
            line = go.AddComponent<LineRenderer>();
            //设置材质
            line.material = new Material(Shader.Find("Sprites/Default"));
            //设置线宽1厘米
            line.widthMultiplier = 0.01f;

            //设置线的颜色是蓝色
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                    new GradientColorKey(Color.blue, 0.0f),
                    new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] {
                    new GradientAlphaKey(1f, 0.0f),
                    new GradientAlphaKey(1f, 1.0f) }
            );
            line.colorGradient = gradient;

            pointNumber = 0;
        }
        /// <summary>
        /// 结束画线
        /// </summary>
        public void EndDraw()
        {
            line = null;
            pointNumber = 0;
        }

        void Update()
        {
            //如果没有在画线，则跳出
            if (line == null)
            {
                return;
            }

            //将当前坐标点坐标添加到轨迹线
            line.positionCount = pointNumber + 1;
            line.SetPosition(pointNumber, point.position);
            pointNumber++;
        }
    }
}

