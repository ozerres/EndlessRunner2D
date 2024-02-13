using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTailEffect : MonoBehaviour
{
    public float startTimeBtwSpawn;
    float timeBtwSpawn;
    public GameObject tailPrefab;

    private void Update()
    {
        if (timeBtwSpawn <= 0) 
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            Destroy(tail, 4f);

        }
        else 
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}

// startTimeBtwSpawn: Kuyruk par�ac���n�n her olu�turulmas� aras�ndaki ba�lang�� s�resini belirten bir float de�i�ken.
// timeBtwSpawn: Kuyruk par�ac���n�n bir sonraki olu�turulmas� i�in kalan s�reyi tutan bir float de�i�ken.
// tailPrefab: Kuyruk par�ac���n�n bir �rne�i olan GameObject tipinde bir nesne.
// Update fonksiyonu, her g�ncelleme �er�evesinde �al���r. Bu fonksiyon, kuyruk par�ac���n�n olu�turulma zamanlamas�n� kontrol eder ve gerekti�inde yeni bir kuyruk par�ac��� olu�turur.
 
// if (timeBtwSpawn >= 0): E�er timeBtwSpawn de�eri 0 veya daha b�y�kse, bir sonraki kuyruk par�ac��� olu�turma zaman� gelmi�tir.

// GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);: Kuyruk par�ac��� �rne�ini, tailPrefab nesnesi kullan�larak, bu MonoBehaviour'un bulundu�u nesnenin konumunda olu�turur.
// Quaternion.identity, kuyruk par�ac���n�n d�nme de�erini varsay�lan olarak ayarlar (d�nme yok).
// timeBtwSpawn = startTimeBtwSpawn;: timeBtwSpawn de�erini, bir sonraki kuyruk par�ac���n�n olu�turulma zaman�n� belirlemek i�in startTimeBtwSpawn de�erine ayarlar.
// Destroy(tail, 4f);: Olu�turulan kuyruk par�ac���n�, olu�turulduktan 4 saniye sonra yok eder.
// else: E�er timeBtwSpawn de�eri 0'dan k���kse, yeni bir kuyruk par�ac��� olu�turma zaman� de�ilse, kalan s�reyi azaltmak i�in timeBtwSpawn de�erini zaman ge�irilen s�re kadar azalt�r.

// timeBtwSpawn -= Time.deltaTime;: timeBtwSpawn de�erini g�nceller ve bir sonraki g�ncelleme �er�evesinde bir sonraki olu�turma zaman� i�in kalan s�reyi azalt�r.