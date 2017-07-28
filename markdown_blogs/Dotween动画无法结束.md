Dotween

```c#
/// <summary>
/// 往上后往前飞并伴随旋转的混合动画，可以重复多次播放
/// </summary>
public class RepeatAnim : MonoBehaviour
{
    private Sequence sequence;
    public bool isPlaying = false;
    public Transform flyTarget;

    // Use this for initialization
    void Start()
    {
        DoStart();
    }

    public void DoStart()
    {
        if (flyTarget != null)
        {
            if (sequence != null)
            {
                sequence.Kill();
                sequence = null;
            }
            if (sequence == null) sequence = DOTween.Sequence();

            DoReset();
            isPlaying = true;

            //使用dowteen的加速度函数
            Tweener upTweener = flyTarget.DOLocalMoveY(flyTarget.localPosition.y + 5, 0.4f);
            upTweener.SetUpdate(true);
            upTweener.SetEase(Ease.InOutFlash);
            sequence.Insert(0, upTweener);

            Tweener downTweener = flyTarget.DOLocalMoveX(flyTarget.localPosition.x + 5, 0.6f);
            downTweener.SetUpdate(true);
            downTweener.SetEase(Ease.InCubic);
            sequence.Insert(0.6f, downTweener);

            sequence.Insert(0, flyTarget.DOLocalRotate(new Vector3(0, 180, 0), 1.0f, RotateMode.WorldAxisAdd));
            sequence.OnComplete(() =>
            {
                Debug.LogFormat("动画播放完成");
            });
        }
    }

    public void DoReset()
    {
        if (flyTarget != null)
        {
            flyTarget.localPosition = Vector3.zero;
            flyTarget.localRotation = Quaternion.identity;
            flyTarget.localScale = Vector3.one;
        }
        isPlaying = false;
    }
}
```