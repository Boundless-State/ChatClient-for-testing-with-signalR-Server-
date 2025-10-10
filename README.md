# 💬 ChatClient (Console)

En enkel **SignalR-klient** som ansluter till din egen chattserver för att testa extern kommunikation och meddelandeöverföring.  
Den fungerar tillsammans med ditt SignalR-projekt — t.ex. [ChatWebAppSignalR](https://github.com/Boundless-State/ChatWebAppSignalR).

---

## 🧩 Syfte

Den här konsolklienten är byggd för **testning**.  
Du kan använda den för att:
- Kontrollera att din SignalR-server accepterar anslutningar utifrån.
- Se om externa klienter kan ta emot och skicka meddelanden korrekt.
- Snabbt testa ändringar i din hubb utan att behöva starta webben.

---

## ⚙️ Konfiguration

Innan du kör klienten, öppna **`appsettings.json`** och uppdatera hubbadressen:

```json
{
  "Chat": {
    "ServerUrl": "https://localhost:7119/chat"
  }
}
```

Om din SignalR-server körs i molnet eller på annan port, byt ut URL:en.

---

## 🚀 Starta klienten

1. Bygg och kör projektet:

   ```bash
   dotnet run --project ChatClient
   ```

2. Ange ditt användarnamn när programmet startar.

3. Skriv ett meddelande och tryck **Enter** för att skicka.

4. Öppna flera terminaler för att testa realtidskommunikation mellan klienter.

---

## 🔒 Säkerhet & Anslutning

Klienten använder samma principer som webben:
- Ansluter till hubben via **SignalR** över WebSockets.
- Kommunicerar i realtid med servern.
- Ingen lokal lagring — allt sker i minnet under körning.

Om din server kräver HTTPS-certifikat:
```bash
dotnet dev-certs https --trust
```

---

## 🧠 Tips

| Problem | Lösning |
|----------|----------|
| Klienten ansluter inte | Kontrollera att ChatServer är igång och att hubb-URL stämmer. |
| Inga meddelanden tas emot | Säkerställ att hubbnamn (`/chat`) matchar serverns `MapHub`-konfiguration. |
| Certifikatfel | Använd `--trust`-kommandot ovan eller kör servern utan HTTPS under test. |

---


## 🌐 Relaterat projekt

➡️ [ChatWebAppSignalR (MVC-version)](https://github.com/Boundless-State/ChatWebAppSignalR)

Det här är den webb- och SignalR-server som ChatClient är tänkt att ansluta till.

---

## 📄 Licens

Fritt att använda för **utbildning, utveckling och testning**.
