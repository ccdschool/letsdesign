# CSV Viewer
## Inkrement 1
* Anforderungsanalyse
* Entwurf mit Softwarezelle
* Flow-Design und Implementation für 1. Interaktion: bei Programmstart die erste Seite anzeigen

Video: https://www.youtube.com/watch?v=53JUCcKWm5w

## Inkrement 2
* Flow-Design und Implementation für 2. Interaktion: Blättern zur ersten Seite
* dito für 3. Interaktion. Blättern zur letzten Seite

Video: https://www.youtube.com/watch?v=qTeS1WiGHvY

## Inkrement 3
* Flow-Design und Implementation für 4. Interaktion: Blättern zur nächsten Seite
* dito für 5. Interaktion: Blättern zur vorherigen Seiten
* Refactoring, um den Datenfluss zwischen den Portalen (CLI, Console) bei den Interaktionen an einem zu verdrahten

Video: https://www.youtube.com/watch?v=4qSpRgth2MI

## Inkrement 4
* Flow-Design und Implementation, um Seitenlänge auf der Kommandozeile zu übergeben; betrifft 1. Interaktion
* Refactoring: Interaktionen in eigene Klasse herausziehen
* Klassendiagramm

Video: https://youtu.be/ic_DVQ97hLU

---

Geplant:

Inkrement 5
* Refaktorisieren: Interaktionen über ctor mit Abhängigkeiten versorgen
* `App{}` testbar machen
  * Interfaces für Portale einführen
  * Testprojekt anlegen
  * Mocks für Portale implementieren
  * Akzeptanztest aufsetzen, der durch eine Testdatei blättert
