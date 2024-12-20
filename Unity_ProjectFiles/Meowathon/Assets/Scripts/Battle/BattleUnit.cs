using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] CatBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Cat Cat { get; set; }
    
    Image image;
    Vector3 orginalPos;
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        orginalPos = image.transform.localPosition;
        originalColor = image.color;
    }
    public void Setup()
    {
        Cat = new Cat(_base, level);
        if (isPlayerUnit)
            image.sprite = Cat.Base.BackSprite;
        else
            image.sprite = Cat.Base.FrontSprite;
            image.color = originalColor; 
            PlayEnterAnimation();
    }
    public void PlayEnterAnimation() 
    {
        if (isPlayerUnit)
            image.transform.localPosition = new Vector3(-500f, orginalPos.y);
        else
            image.transform.localPosition = new Vector3(500f, orginalPos.y);

        image.transform.DOLocalMoveX(orginalPos.x, 1f);
    }
    public void PlayAttackAnimation()
    {
        var sequence = DOTween. Sequence();
        if (isPlayerUnit)
            sequence. Append(image.transform.DOLocalMoveX (orginalPos.x + 50f, 0.25f));
        else
            sequence.Append(image.transform.DOLocalMoveX(orginalPos.x - 50f, 0.25f));
        sequence.Append(image.transform.DOLocalMoveX(orginalPos.x, 0.25f));
    }
    public void PlayHitAnimation()
    {
        var sequence = DOTween. Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor (originalColor, 0.1f));

    }
    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY (orginalPos.y -150f, 0.5f)); 
        sequence.Join(image.DOFade (0f, 0.5f));
    }
}
