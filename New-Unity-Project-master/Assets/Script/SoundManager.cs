using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;                        // 배경음악.
    public AudioSource areaConqSource;                      // 점령전 시작.
    public AudioSource generalSource;                       // 장수 등용, 파직, 교체에서 사용될 효과음.
    public AudioSource inWarIngREENDSource;                 // ING 혹은 반란 같은 전쟁이 일어날 경우 팝업에서 사용될 효과음.
    public AudioSource positiveSource;                      // 긍정적인 음악.
    public AudioSource negativeSource;                      // 부정적인 음악.
    public AudioSource gameEndingSource;                    // 승리하여 종료된 경우.
    public AudioSource coinDropSource;


    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // 사운드 재생 관련. //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void AreaConqPlay() { areaConqSource.Play(); }
    public void GeneralPlay() { generalSource.Play(); }
    public void InWarIngREENDPlay() { inWarIngREENDSource.Play(); }
    public void InWarIngREENDStop() { inWarIngREENDSource.Stop(); }
    public void PositivePlay() { positiveSource.Play(); }
    public void NegativePlay() { negativeSource.Play(); }
    public void GameEndingPlay() { gameEndingSource.Play(); }
    public void CoinDropPlay() { coinDropSource.Play(); positiveSource.Play(); }
    public void MusicPlay() { musicSource.Play(); }
}
