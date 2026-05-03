# 🏨 RapidApiHotelProject

Modern web teknolojileri kullanılarak geliştirilmiş, tüm verilerini **canlı API servislerinden** çeken kapsamlı bir **otel arama ve dashboard platformu**.

Bu proje, yalnızca otel listeleyen bir uygulama değil; aynı zamanda farklı veri kaynaklarını bir araya getirerek kullanıcıya **zengin ve gerçek zamanlı bir deneyim** sunmayı amaçlar.

---

## 🚀 Öne Çıkan Özellikler

### 📊 Dashboard

Farklı API servislerinden alınan veriler tek bir panelde sunulur:

- 🌤️ Anlık hava durumu bilgisi  
- 💱 TRY bazlı döviz kurları  
- ⛽ ABD eyaletlerine göre yakıt fiyatları  
- 🪙 Kripto para piyasası verileri  
- 📰 Güncel haber başlıkları  
- 🍽️ Günün yemeği  

> Tüm veriler gerçek zamanlı olarak API üzerinden çekilmektedir.

---

### 🏨 Otel Arama Sistemi

Kullanıcıya esnek ve güçlü filtreleme imkanı sunar:

- 📍 Şehre göre arama  
- 📅 Giriş / çıkış tarihi seçimi  
- 👥 Misafir sayısı belirleme  
- 💲 Para birimi seçimi  
- 🌐 Dil seçimi  
- 💸 Fiyat aralığı filtreleme  

🔄 **2 Aşamalı API Süreci:**
1. `SearchDestination` → Lokasyon ID bulunur  
2. `SearchHotels` → Oteller listelenir  

---

### 🛎️ Otel Detay Sayfası

Seçilen otel için kapsamlı bilgi sunumu:

- 🖼️ Fotoğraf galerisi (ayrı API endpoint)  
- ⭐ Otel özellikleri ve öne çıkanlar (highlights)  
- 🏨 Tesis bilgileri  
- 💰 Dinamik fiyat hesaplama (gece × fiyat)  
- 💬 Gerçek kullanıcı yorumları  

---

## 🧩 Kullanılan Teknolojiler

### 🔧 Backend
- ASP.NET Core MVC (.NET 6)
- IHttpClientFactory
- System.Text.Json

### 🎨 Frontend
- Bootstrap 5
- Bootstrap Icons

### 🌐 API Servisleri
- RapidAPI
  - Booking.com API
  - Weather API
  - Exchange Rates API
  - Fuel Prices API
  - Crypto Market API
  - News API
- TheMealDB API

---

## ⚙️ Kurulum

### 1️⃣ API Abonelikleri

[RapidAPI](https://rapidapi.com) üzerinden aşağıdaki servisleri aktif edin:

- Booking.com (booking-com15)
- Weather API
- Exchange Rates
- Fuel Gas Price
- Crypto Market Prices
- Real-Time News Data

---

### 2️⃣ API Key Tanımlama

`appsettings.json` dosyasına kendi API anahtarınızı ekleyin:

```json
"RapidApi": {
  "ApiKey": "YOUR_API_KEY_HERE"
}
```
3. Projeyi çalıştırı:
```json
dotnet run
```
