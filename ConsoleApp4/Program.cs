
class Program
{
    // Müşteri sınıfı
    // Bu sınıf, her bir müşterinin adını ve işlem önceliğini tutar.
    class Musteri
    {
        // Müşterinin adı
        public string Ad { get; set; }

        // Müşterinin işlem önceliği (1: Acil, 2: Orta, 3: Normal)
        public int Oncelik { get; set; }

        // Constructor (yapıcı metod) - Müşteri nesnesi oluşturulurken adı ve önceliği belirler.
        public Musteri(string ad, int oncelik)
        {
            Ad = ad;            // Müşterinin adı
            Oncelik = oncelik;  // Müşterinin önceliği
        }

        // ToString metodu - Müşteriyi ekrana yazdırırken formatlı bir çıktı verir.
        public override string ToString()
        {
            return $"{Ad} - Öncelik: {Oncelik}"; // Müşterinin adı ve önceliği ile formatlı çıktı
        }
    }

    // Banka Kuyruğu sınıfı
    // Bu sınıf, banka işlemleri için farklı önceliklerdeki kuyrukları yönetir.
    class BankaKuyrugu
    {
        // Üç farklı öncelik grubunu temsil eden kuyruklar
        public Queue<Musteri> AcilKuyrugu { get; private set; }    // Acil işlemler için kuyruk
        public Queue<Musteri> OrtaKuyrugu { get; private set; }    // Orta öncelikli işlemler için kuyruk
        public Queue<Musteri> NormalKuyrugu { get; private set; }  // Normal işlemler için kuyruk

        // Constructor - Kuyruklar başlatılır.
        public BankaKuyrugu()
        {
            AcilKuyrugu = new Queue<Musteri>();   // Acil işlem kuyruğunu başlat
            OrtaKuyrugu = new Queue<Musteri>();   // Orta işlem kuyruğunu başlat
            NormalKuyrugu = new Queue<Musteri>(); // Normal işlem kuyruğunu başlat
        }

        // Kuyruğa müşteri ekleme fonksiyonu
        // Müşteri, önceliğine göre uygun kuyruğa eklenir.
        public void EnqueueMusteri(Musteri musteri)
        {
            // Müşterinin önceliğine göre doğru kuyruğa ekleme yapılır
            switch (musteri.Oncelik)
            {
                case 1: // Acil işlem
                    AcilKuyrugu.Enqueue(musteri);  // Müşteriyi Acil kuyruğuna ekle
                    Console.WriteLine($"{musteri} - Acil işlem kuyruğuna eklendi.");
                    break;

                case 2: // Orta öncelikli işlem
                    OrtaKuyrugu.Enqueue(musteri);  // Müşteriyi Orta kuyruğuna ekle
                    Console.WriteLine($"{musteri} - Orta seviye işlem kuyruğuna eklendi.");
                    break;

                case 3: // Normal işlem
                    NormalKuyrugu.Enqueue(musteri);  // Müşteriyi Normal kuyruğuna ekle
                    Console.WriteLine($"{musteri} - Normal işlem kuyruğuna eklendi.");
                    break;

                default:
                    // Geçersiz bir öncelik girildiyse hata verir
                    throw new ArgumentException("Geçersiz öncelik! Geçerli öncelikler 1, 2 ve 3'tür.");
            }
        }

        // Kuyruktan müşteri alma fonksiyonu
        // En yüksek öncelikli kuyruktan müşteri alınır.
        public void DequeueMusteri()
        {
            // En yüksek önceliğe sahip kuyruktan müşteri alınır
            if (AcilKuyrugu.Count > 0)
            {
                var musteri = AcilKuyrugu.Dequeue();  // Acil kuyruğundan ilk müşteriyi al
                Console.WriteLine($"{musteri} - Acil işlem tamamlandı.");
            }
            else if (OrtaKuyrugu.Count > 0)
            {
                var musteri = OrtaKuyrugu.Dequeue();  // Orta kuyruğundan ilk müşteriyi al
                Console.WriteLine($"{musteri} - Orta seviye işlem tamamlandı.");
            }
            else if (NormalKuyrugu.Count > 0)
            {
                var musteri = NormalKuyrugu.Dequeue();  // Normal kuyruğundan ilk müşteriyi al
                Console.WriteLine($"{musteri} - Normal işlem tamamlandı.");
            }
            else
            {
                // Kuyruklar boşsa, mesaj verir
                Console.WriteLine("Kuyrukta bekleyen müşteri yok.");
            }
        }

        // Kuyruğun mevcut durumunu gösterir
        public void KuyrukDurumunuGoster()
        {
            // Kuyrukların durumunu ekrana yazdırır
            Console.WriteLine("\n--- Kuyruk Durumu ---");

            // Acil Kuyruk
            Console.WriteLine("\nAcil Kuyruk:");
            if (AcilKuyrugu.Count == 0) Console.WriteLine("Acil kuyruk boş.");
            foreach (var musteri in AcilKuyrugu)
            {
                Console.WriteLine(musteri);  // Acil kuyruğundaki her müşteriyi yazdır
            }

            // Orta Seviye Kuyruk
            Console.WriteLine("\nOrta Seviye Kuyruk:");
            if (OrtaKuyrugu.Count == 0) Console.WriteLine("Orta seviye kuyruk boş.");
            foreach (var musteri in OrtaKuyrugu)
            {
                Console.WriteLine(musteri);  // Orta kuyruğundaki her müşteriyi yazdır
            }

            // Normal Kuyruk
            Console.WriteLine("\nNormal Kuyruk:");
            if (NormalKuyrugu.Count == 0) Console.WriteLine("Normal kuyruk boş.");
            foreach (var musteri in NormalKuyrugu)
            {
                Console.WriteLine(musteri);  // Normal kuyruğundaki her müşteriyi yazdır
            }
        }
    }

    static void Main()
    {
        // BankaKuyrugu sınıfından bir nesne oluşturuluyor
        var bankaKuyrugu = new BankaKuyrugu();

        // Kuyruğa müşteri ekleme işlemleri
        bankaKuyrugu.EnqueueMusteri(new Musteri("Ali", 1));   // Acil işlem için müşteri ekle
        bankaKuyrugu.EnqueueMusteri(new Musteri("Ayşe", 3));  // Normal işlem için müşteri ekle
        bankaKuyrugu.EnqueueMusteri(new Musteri("Mehmet", 2)); // Orta işlem için müşteri ekle
        bankaKuyrugu.EnqueueMusteri(new Musteri("Fatma", 1));  // Acil işlem için müşteri ekle

        // Kuyruk durumunu gösterme
        bankaKuyrugu.KuyrukDurumunuGoster();

        // Kuyruktan müşteri alma işlemi
        Console.WriteLine("\n--- İşlem Yapılan Müşteriler ---");
        bankaKuyrugu.DequeueMusteri();  // En yüksek öncelikli müşteri alınır
        bankaKuyrugu.DequeueMusteri();  // Bir sonraki yüksek öncelikli müşteri alınır
        bankaKuyrugu.DequeueMusteri();  // Diğer müşteri alınır
        bankaKuyrugu.DequeueMusteri();  // Son müşteri alınır

        // Kuyruk durumunu tekrar gösterme
        bankaKuyrugu.KuyrukDurumunuGoster();  // Kuyrukta kalan müşterileri göster
    }
}
