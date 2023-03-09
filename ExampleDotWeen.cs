using UnityEngine;
using DG.Tweening;

public class MoveObject : MonoBehaviour
{
    public Transform targetPosition;
    public float duration;
    public void MoveToPoint()
    {
        transform.DOMove(targetPosition.position, duration);
    }

    public Transform targetRotation;
    public float duration;
    public void Roration()
    {
        transform.DORotate(targetRotation.eulerAngles, duration);
    }
    
    public Vector3 targetScale;
    public float duration;
    public void Scale()
    {
        transform.DOScale(targetScale, duration);
    }
    
    public Color targetColor;
    public float duration;
    public void ChangeColor()
    {
        Material material = GetComponent<Renderer>().material;
        material.DOColor(targetColor, duration);
    }
    
    public float distance;
    public float duration;
    public void ZigZagMovement()
    {
        transform.DOMoveX(transform.position.x + distance, duration).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
    }
    
    public float duration;
    public float strength;
    public int vibrato;
    public void Shake()
    {
        transform.DOShakePosition(duration, strength, vibrato);
    }

    public float duration;
    public float targetAlpha;
    public void FadeObject()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(targetAlpha, duration);
    }

    public Transform targetPosition;
    public float duration;
    public void ChainTweens()
    {
        transform.DOMove(targetPosition.position, duration).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DORotate(new Vector3(0f, 180f, 0f), duration).SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        transform.DOScale(2f, duration).SetEase(Ease.OutQuad);
                    });
            });
    }

    public AnimationClip animationClip;
    public float duration = 1f;
    public void PlayAnimation()
    {
        // Play the animation clip on the object with DOTween
        transform.DOLocalRotateQuaternion(Quaternion.identity, duration)
            .SetEase(Ease.OutElastic)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public Transform[] waypoints;
    public float duration = 2f;
    public void FollowPath()
    {
        // Move the object along the path defined by the waypoints
        transform.DOLocalPath(waypoints, duration, PathType.CatmullRom, PathMode.Full3D)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public Vector3 targetScale;
    public float duration = 1f;
    public float delay = 0.5f;
    public void ScaleWathDelay()
    {
        // Scale the object to the target scale with a delay and custom easing function
        transform.DOScale(targetScale, duration)
            .SetEase(Ease.InOutElastic)
            .SetDelay(delay);
    }

    public AudioClip soundEffect;
    public float volume = 1f;
    public float delay = 0.5f;
    public void PlaySound()
    {
        // Play the sound effect with a delay and a callback function
        transform.DOScale(Vector3.one, 1f)
            .SetDelay(delay)
            .OnComplete(() => AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume));
    }

    public float radius = 2f;
    public float speed = 2f;
    public void CircularRotation()
    {
        // Rotate the object in a circular path with a DOPath method
        transform.DOLocalPath(new[] {
            new Vector3(0, 0, 0),
            new Vector3(radius, 0, 0),
            new Vector3(0, 0, 0),
            new Vector3(-radius, 0, 0),
            new Vector3(0, 0, 0),
        }, speed, PathType.Circular, PathMode.Full3D)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Restart);
    }
}