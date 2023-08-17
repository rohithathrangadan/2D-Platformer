using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;

    private float value;

    private void Start()
    {
        Time.timeScale = 1.0f;//if navigating to home from pause menu, set timeScale to 1
        mixer.GetFloat("volume",out value );
        volumeSlider.value = value;

    }
    public void SetVolume()
    {
      mixer.SetFloat("volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
