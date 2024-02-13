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

// startTimeBtwSpawn: Kuyruk parçacýðýnýn her oluþturulmasý arasýndaki baþlangýç süresini belirten bir float deðiþken.
// timeBtwSpawn: Kuyruk parçacýðýnýn bir sonraki oluþturulmasý için kalan süreyi tutan bir float deðiþken.
// tailPrefab: Kuyruk parçacýðýnýn bir örneði olan GameObject tipinde bir nesne.
// Update fonksiyonu, her güncelleme çerçevesinde çalýþýr. Bu fonksiyon, kuyruk parçacýðýnýn oluþturulma zamanlamasýný kontrol eder ve gerektiðinde yeni bir kuyruk parçacýðý oluþturur.
 
// if (timeBtwSpawn >= 0): Eðer timeBtwSpawn deðeri 0 veya daha büyükse, bir sonraki kuyruk parçacýðý oluþturma zamaný gelmiþtir.

// GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);: Kuyruk parçacýðý örneðini, tailPrefab nesnesi kullanýlarak, bu MonoBehaviour'un bulunduðu nesnenin konumunda oluþturur.
// Quaternion.identity, kuyruk parçacýðýnýn dönme deðerini varsayýlan olarak ayarlar (dönme yok).
// timeBtwSpawn = startTimeBtwSpawn;: timeBtwSpawn deðerini, bir sonraki kuyruk parçacýðýnýn oluþturulma zamanýný belirlemek için startTimeBtwSpawn deðerine ayarlar.
// Destroy(tail, 4f);: Oluþturulan kuyruk parçacýðýný, oluþturulduktan 4 saniye sonra yok eder.
// else: Eðer timeBtwSpawn deðeri 0'dan küçükse, yeni bir kuyruk parçacýðý oluþturma zamaný deðilse, kalan süreyi azaltmak için timeBtwSpawn deðerini zaman geçirilen süre kadar azaltýr.

// timeBtwSpawn -= Time.deltaTime;: timeBtwSpawn deðerini günceller ve bir sonraki güncelleme çerçevesinde bir sonraki oluþturma zamaný için kalan süreyi azaltýr.