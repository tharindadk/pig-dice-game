using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public Sprite die1;
    public Sprite die2;
    public Sprite die3;
    public Sprite die4;
    public Sprite die5;
    public Sprite die6;
    public LogicScript logic;
    public AudioSource diceRollSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        diceRollSoundSource.Stop();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeNumber()
    {
        diceRollSoundSource.Play();
        var spriteRender = gameObject.GetComponent<SpriteRenderer>();
        var number = Random.Range(1, 7);
        switch (number)
        {
            case 1:
                spriteRender.sprite = die1;
                break;
            case 2:
                spriteRender.sprite = die2;
                break;
            case 3:
                spriteRender.sprite = die3;
                break;
            case 4:
                spriteRender.sprite = die4;
                break;
            case 5:
                spriteRender.sprite = die5;
                break;
            case 6:
                spriteRender.sprite = die6;
                break;
        }
        logic.addScore(number);
    }
}
