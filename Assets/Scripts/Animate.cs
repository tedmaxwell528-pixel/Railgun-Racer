using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate
{
    static Color active = new Color(1,1,1,1);
    static Color inactive = new Color(1,1,1,0);

    public static IEnumerator CreateAnimation(List<Sprite> frames, SpriteRenderer sprite, float delay){
        sprite.color = active;
        foreach (Sprite s in frames){
            sprite.sprite = s;
            yield return new WaitForSeconds(delay);
        }
        sprite.color = inactive;
    }
}
