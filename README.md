# ChatApp with SignalR

Bu proje, .NET SignalR kullanarak oluşturulmuş basit ve güçlü bir chat uygulamasıdır. Kullanıcıların gerçek zamanlı olarak mesaj göndermesine ve almasına olanak tanır.
Aşağıda bu projenin nasıl çalıştığına, nasıl kurulacağına ve nasıl katkıda bulunabileceğinize dair detaylı bilgiler bulacaksınız.

Özellikler
Gerçek Zamanlı Mesajlaşma: Kullanıcılar anında mesaj gönderip alabilirler. SignalR kullanımı sayesinde mesajlar neredeyse gecikmesiz iletilir.
Kullanıcı Bağlantı Yönetimi: Kullanıcıların çevrimiçi veya çevrimdışı olup olmadığını takip edebilir, kullanıcı bağlantı durumlarını yönetebilirsiniz.
Sunucuya Bağlantı Durumu Takibi: Kullanıcıların sunucuya bağlı olup olmadığını kontrol edebilir, bağlantı durumlarını görüntüleyebilirsiniz.
Çoklu Chat Odaları: Kullanıcıların farklı odalarda sohbet etmelerine olanak tanır.


# Kurulum
1. Proje Deposunu Klonlama
Öncelikle, proje deposunu yerel makinenize klonlayın:
git clone https://github.com/BatuhanKayaoglu/ChatApp-with-SignalR.git
cd ChatApp-with-SignalR

# Kullanım
1. Chat Odasına Katılma
Mevcut chat odalarından birine katılabilir veya yeni bir chat odası oluşturabilirsiniz. Bir odaya katıldıktan sonra, diğer kullanıcılarla anında mesajlaşmaya başlayabilirsiniz.

2. Mesaj Gönderme ve Alma
Mesaj gönderme ve alma işlemleri gerçek zamanlı olarak gerçekleşir. Yazdığınız mesajlar anında diğer kullanıcılara iletilir ve onların mesajları da anında size ulaşır.

3. Kullanıcı Durumu Takibi
Uygulama, kullanıcıların çevrimiçi veya çevrimdışı olup olmadığını gösterir. Böylece hangi kullanıcıların aktif olduğunu görebilirsiniz.

## Proje Yapısı

ChatApp-with-SignalR/
│
├── ChatApp/                  # .NET Core backend projesi
│   ├── Controllers/          # API Controller'ları
│   ├── Hubs/                 # SignalR Hubs
│   ├── Models/               # Veri modelleri
│   ├── Services/             # İş mantığı ve servisler
│   └── Program.cs            # Uygulama giriş noktası
│
├── ClientApp/                # React frontend projesi
│   ├── src/                  # Kaynak kodlar
│   ├── public/               # Statik dosyalar
│   ├── package.json          # Bağımlılıklar
│   └── .env                  # Çevre değişkenleri
│
├── .gitignore                # Git dosyası
├── README.md                 # Proje tanıtım dosyası
└── LICENSE                   # Lisans dosyası
