using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director;
    public string nextSceneName;

    public GameObject playButton;

    private void Start()
    {
        director.stopped += OnAnimationFinished;
    }

    public void StartAnimation()
    {
        playButton.SetActive(false);
        director.Play();
    }

    private void OnAnimationFinished(PlayableDirector director)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
