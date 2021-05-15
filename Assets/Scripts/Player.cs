using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float sideBorders = 4f;
    [SerializeField] float speedMultiplier = 0.35f;
    [SerializeField] float minY = -7.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var multiplier = Time.deltaTime * speedMultiplier;
        var deltaX = Input.GetAxis("Horizontal") * multiplier;
        var newX = transform.position.x + deltaX;
        var clampedX = Mathf.Clamp(newX, -sideBorders, sideBorders);
        var deltaY = Input.GetAxis("Vertical") * multiplier;
        var newY = transform.position.y + deltaY;
        var clampedY = Mathf.Clamp(newY, minY, minY + sideBorders);
        transform.position = new Vector2(clampedX, clampedY);
    }
}
