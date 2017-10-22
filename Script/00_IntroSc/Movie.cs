using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movie : MonoBehaviour {
    VideoPlayer introMovie;
    // Use this for initialization
    void Start () {
        // this line of code will make the Movie Texture begin playing
        introMovie = GetComponent<VideoPlayer>();
        introMovie.Play();
    }

    // Update is called once per frame
    void Update () {
        if(!introMovie.isPlaying) SceneManager.LoadScene("LoginScene");
    }
}
