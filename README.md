# 🔦 BLACKOUT

> *"Jangan sampai ketahuan. Jangan sampai gelap menelanmu."*

**BLACKOUT** adalah game 2D top-down bergenre mystery/stealth survival. Kamu berperan sebagai penjaga malam yang terjebak di gedung kantor 5 lantai saat mati lampu total. Satu-satu nyalakan generator, hindari ancaman di kegelapan, dan kabur sebelum terlambat.

---

## 🎮 Gameplay

- Jelajahi 5 lantai gedung dalam kondisi gelap total
- Gunakan senter untuk menerangi jalan — tapi ingat, musuh bisa mendeteksimu
- Temukan dan aktifkan generator di setiap lantai
- Capai pintu darurat sebelum "sesuatu" menemukanmu

### Kontrol

| Input | Aksi |
|-------|------|
| `WASD` / Arrow Keys | Gerak 8 arah |
| Mouse | Arahkan senter |
| `E` (tahan) | Aktifkan generator / buka pintu |
| `Shift` | Gerak pelan (tidak bersuara) |
| `ESC` | Pause |

---

## ⚙️ Mekanik Utama

**🔦 Sistem Senter**
Cahaya senter mengikuti arah mouse. Area di luar jangkauan senter = gelap total. Musuh tidak terlihat jika di luar lingkaran cahaya.

**👁️ Sistem Deteksi Musuh**
Musuh diam di posisi spawn. Jika kamu masuk dalam radius deteksinya, mereka langsung mengejar. Keluar dari radius = musuh berhenti dan kembali ke posisi awal.

**⚡ Sistem Generator**
Tahan `E` selama 2 detik untuk mengaktifkan generator. Setelah aktif, pintu darurat lantai tersebut terbuka.

---

## 🗺️ Level

| Lantai | Deskripsi |
|--------|-----------|
| Lantai 1 | Tutorial — kenalan sama mekanik dasar |
| Lantai 2 & 3 | Koridor lebih sempit, 2 musuh, timer aktif |
| Lantai 4 & 5 | Layout kompleks, 3 musuh, salah satu berpatroli |

---

## 🛠️ Tech Stack

| Komponen | Detail |
|----------|--------|
| Engine | Unity 6.0 LTS |
| Render Pipeline | URP (Universal Render Pipeline) |
| Bahasa | C# |
| Lighting | Unity 2D Lights |
| Platform | PC — WebGL / Standalone |

---

## 📁 Struktur Project

```
Assets/
├── _Scenes/        # MainMenu, Level_01–05, GameOver
├── _Scripts/
│   ├── Player/     # PlayerMovement, FlashlightController, dll
│   ├── Enemy/      # EnemyAI, EnemyDetection
│   └── Systems/    # GameManager, SaveManager, UIManager, dll
├── _Prefabs/       # Player, Enemy, Generator, Door
├── _Sprites/       # Semua sprite & tileset (pixel art 16x16 / 32x32)
├── _Audio/         # SFX & BGM
└── _UI/            # Canvas prefab, font, icon
```

---

## 🎨 Visual Style

- Pixel art 16x16 (tile) dan 32x32 (karakter/prop)
- Palet dominan gelap: hitam, abu tua, biru tengah malam
- Aksen: oranye senter, merah bahaya, hijau generator aktif
- Referensi: Hotline Miami (top-down), Teleglitch (efek senter), Alien: Isolation (atmosfer)

---

## 🔊 Audio

- BGM ambient: drone suara rendah, gelap dan menegangkan
- SFX: langkah, generator menyala, suara musuh mengejar, jumpscare game over
- Audio adaptif: musik makin tegang saat musuh mendekat (Level 4–5)

---

## 💾 Save System

Progress disimpan otomatis setelah menyelesaikan Lantai 4. Saat game over, pilih mulai dari awal atau lanjut dari lantai terakhir yang tersimpan.

---

## 🚀 Cara Main

1. Download / clone repo ini
2. Buka project di **Unity 6.0 LTS**
3. Pastikan menggunakan **URP (Universal Render Pipeline)**
4. Buka scene `MainMenu` dan tekan Play

---

*Dibuat dalam 4 hari · Unity 6.0 LTS · 2D Top-Down Mystery*
