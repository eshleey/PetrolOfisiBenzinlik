using UnityEngine;

public class Tanker : MonoBehaviour
{
    public GameObject gasoline;
    [Range(0, 1)]
    public float fillAmount = 1.0f;
    private Vector3 initialScale;
    public float currentCapacity = 0f; //Oyunun baþlagýcýndaki varsayýlan kapasite
    public float maxCapacity = 100f; //Tankerin maximum kapasitesi
    public GameObject Point;
    public float fillRate = 20f; //Fillamount un hangi oranda artacaðýný gösteren bir nevi dolumhýzý
    public bool gasFilling = false; //eðer true ise doldurmayý baþlatýyor false ise durduruyor baþlangýçta false vermemim sebebi oyun baþlar baþlamaz dolum yapmasýný istemediðim için

    private void Start()
    {
        initialScale = gasoline.transform.localScale;
        UpdateFillAmount();
    }

    private void Update()
    {
        currentCapacity = fillAmount * maxCapacity;

        if (gasFilling)  //add gasoline arttýrýlan deðeri dolum hýzýyla beraber tankeri dolduruyor burasý true olunca 
        {
            AddGasoline(fillRate * Time.deltaTime);
        }

        gasoline.transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z * fillAmount);

        if (currentCapacity >= maxCapacity)  // burada maxkapasiteye ulaþtýðýnda dolumu sonlandýrmak için yapýldý
        {
            gasFilling = false;
            currentCapacity = 0f;
        }
    }

    private void UpdateFillAmount()
    {
        currentCapacity = Mathf.Clamp(currentCapacity, 0f, maxCapacity);  //burada clamp fonksiyonuna göre baþlangýç deðeri minumum alacaðý deðer ve maximum alacaðý deðeri alýyoruz
        fillAmount = currentCapacity / maxCapacity;   // buradada doluluk oranýný alýyoruz 
    }

    public void AddGasoline(float amount)
    {
        currentCapacity += amount;   //burada amont deðerini arttýrýyor
        UpdateFillAmount();
    }

    public void RemoveGasoline(float amount)
    {
        currentCapacity -= amount;   //burada amont deðerini azaltýyor bunu þuanda kullanmadým bunu benzin arabaya baðlanýnca kullanacaðým
        UpdateFillAmount();
    }

    public void GasStartFilling()
    {
        gasFilling = true;   // bu fonksiyonu gasFillingi kontrol etmek için yazdým true olunca baþlýyor
    }

    public void GasStopFilling()
    {
        gasFilling = false;   // bu fonksiyonu gasFillingi kontrol etmek için yazdým false olunca duruyor
    }
}