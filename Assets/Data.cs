[System.Serializable]
public class Data
{
    public int deathCounter;
    public string stage;
    public float volume;

    public Data(int _deathCounter, string _stage, float _volume)
    {
        deathCounter = _deathCounter;
        stage = _stage;
        volume = _volume;
    }
}
