# 🧩 Unity Scene Switcher Overlay

Unity editöründe sahneler (scenes) arasında hızlı ve pratik şekilde geçiş yapmak için geliştirilmiş, **overlay panel** olarak çalışan mini bir araçtır.  
Scene View üzerinde istediğin yere sürükleyebilir, tek tıkla istediğin sahneyi açabilirsin.  
Özellikle büyük projelerde menüler, test sahneleri ve level’lar arasında geçişi büyük ölçüde kolaylaştırır.

## 🚀 Özellikler

- **Tüm sahneleri otomatik listeler:** Projedeki tüm `.unity` dosyalarını dinamik olarak gösterir.
- **Tek tıkla geçiş:** Her sahne için bir buton, tıklayınca hemen o sahneyi açar.
- **Refresh (Yenile) butonu:** Yeni sahne eklediğinde ya da bir sahne silindiğinde listeyi kolayca güncelleyebilirsin.
- **Sürükle-bırak panel:** Overlay yapısı sayesinde Scene View üstünde istediğin yere sabitleyebilirsin.
- **Kullanımı ve kurulumu çok kolay!**

## 🛠️ Kurulum

1. **Unity 2021.2 veya üzeri bir sürüm** kullanmalısın. (Overlay API bu sürümden itibaren var.)
2. `Editor` klasörüne `SceneSwitcherOverlay.cs` dosyasını ekle.
3. (Tavsiye) Panelin otomatik olarak açılmasını istiyorsan Unity Editöründen `Window > Layouts` altında kendi layout’una ekle.

## ⚡️ Kullanım

- **Scene View** ekranında sağ üstte ya da kenarlarda “Scene Switcher” adında bir panel göreceksin.
- Paneli istediğin yere sürükleyip sabitleyebilirsin.
- Listeden istediğin sahnenin butonuna basınca, o sahne açılır.
- **Refresh** butonuna tıklayarak paneldeki sahne listesini güncelleyebilirsin.

## 📦 Kodun Temel Mantığı

- `Overlay` attribute’u ile Scene View üzerine taşınabilir bir panel ekleniyor.
- Projedeki tüm sahneler otomatik olarak tespit ediliyor.
- Sahne değiştirirken değişiklikleri kaydedip kaydetmek istemediğini sorar.
- “Refresh” butonu ile sahne listesi anında güncellenir.
