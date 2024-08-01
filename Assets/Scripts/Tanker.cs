using UnityEngine;

public class Tanker : MonoBehaviour
{
    public GameObject gasoline;
    [Range(0, 1)]
    public float fillAmount = 1.0f;
    private Vector3 initialScale;
    public float currentCapacity = 0f; //Oyunun ba�lag�c�ndaki varsay�lan kapasite
    public float maxCapacity = 100f; //Tankerin maximum kapasitesi
    public GameObject Point;
    public float fillRate = 20f; //Fillamount un hangi oranda artaca��n� g�steren bir nevi dolumh�z�
    public bool gasFilling = false; //e�er true ise doldurmay� ba�lat�yor false ise durduruyor ba�lang��ta false vermemim sebebi oyun ba�lar ba�lamaz dolum yapmas�n� istemedi�im i�in

    private void Start()
    {
        initialScale = gasoline.transform.localScale;
        UpdateFillAmount();
    }

    private void Update()
    {
        currentCapacity = fillAmount * maxCapacity;

        if (gasFilling)  //add gasoline artt�r�lan de�eri dolum h�z�yla beraber tankeri dolduruyor buras� true olunca 
        {
            AddGasoline(fillRate * Time.deltaTime);
        }

        gasoline.transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z * fillAmount);

        if (currentCapacity >= maxCapacity)  // burada maxkapasiteye ula�t���nda dolumu sonland�rmak i�in yap�ld�
        {
            gasFilling = false;
            currentCapacity = 0f;
        }
    }

    private void UpdateFillAmount()
    {
        currentCapacity = Mathf.Clamp(currentCapacity, 0f, maxCapacity);  //burada clamp fonksiyonuna g�re ba�lang�� de�eri minumum alaca�� de�er ve maximum alaca�� de�eri al�yoruz
        fillAmount = currentCapacity / maxCapacity;   // buradada doluluk oran�n� al�yoruz 
    }

    public void AddGasoline(float amount)
    {
        currentCapacity += amount;   //burada amont de�erini artt�r�yor
        UpdateFillAmount();
    }

    public void RemoveGasoline(float amount)
    {
        currentCapacity -= amount;   //burada amont de�erini azalt�yor bunu �uanda kullanmad�m bunu benzin arabaya ba�lan�nca kullanaca��m
        UpdateFillAmount();
    }

    public void GasStartFilling()
    {
        gasFilling = true;   // bu fonksiyonu gasFillingi kontrol etmek i�in yazd�m true olunca ba�l�yor
    }

    public void GasStopFilling()
    {
        gasFilling = false;   // bu fonksiyonu gasFillingi kontrol etmek i�in yazd�m false olunca duruyor
    }
}