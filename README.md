<h2>README - Projekt Gry Reality Tumor</h2>

<h3>1. Opis Projektu</h3>

Od strony biznesowej
Nasz projekt to gra współpracy dla dwóch graczy, łącząca elementy eksploracji, rozwiązywania zagadek i komunikacji.

**Cel:** Stworzenie immersyjnego środowiska, gdzie gracze muszą współpracować, by osiągnąć sukces. Projekt może znaleźć zastosowanie jako narzędzie edukacyjne rozwijające umiejętności pracy zespołowej lub jako innowacyjna gra rozrywkowa. 

**Rozwiązania:**
Mechanika dwóch połączonych światów: gry i strony internetowej.
Budowanie zaangażowania poprzez kooperacyjne zagadki.
Oferowanie nietypowego modelu rozgrywki łączącego technologie gier i aplikacji webowych.


Od strony technicznej
Użyte technologie:

**Frontend**: HTML, CSS, JavaScript (interfejs strony internetowej jako "konsola" dla drugiego gracza).

**Backend**: Unity 3D (silnik gry), połączony za pomocą WebSocketów z przeglądarką.

**API**: Własnoręcznie stworzone API do komunikacji między grą a stroną internetową.

**Baza danych**: Brak potrzeby przechowywania długotrwałych danych, projekt opiera się na wymianie informacji w czasie rzeczywistym.


<h3>2. Funkcjonalności</h3>

Mechanika drzwi: Gracze muszą współpracować, aby otwierać przejścia w grze.
Podnoszenie przedmiotów: Mechanika umożliwiająca zbieranie ważnych dla rozgrywki obiektów oraz przesuwanie ich w celu rozwiązania zagadek.


<h3>3. Problemy i ich rozwiązania</h3>

Synchronizacja między grą a stroną: Trudności z prawidłowym przekazywaniem danych w czasie rzeczywistym rozwiązano poprzez wdrożenie optymalnych metod WebSocketowych.
Kamera gracza: Niestabilność obrotów kamery podczas intensywnego ruchu została naprawiona przy użyciu Mathf.Clamp do ograniczenia zakresu patrzenia oraz precyzyjniejszej obsługi rotacji osi X i Y.
Mechanika skakania: Kumulacja siły przy wielokrotnych podskokach rozwiązana przez resetowanie osi Y prędkości po wykonaniu skoku.


<h3>4. Komunikacja</h3>

Gra Unity komunikuje się z serwerem WebSocket, przesyłając zdarzenia za pomocą eventów, takich jak na przykład próba utworzenia sesji (GS_tryCreateSession). Serwer odbiera te zdarzenia, przetwarza je i podejmuje odpowiednie akcje. W przypadku zdarzenia od Unity serwer może utworzyć nową sesję i zwrócić do klienta (gry) wygenerowany token sesji. Strona WWW korzysta z WebSocketów do przesyłania zdarzeń, takich jak logowanie do istniejącej sesji (WS_tryLoginSession) czy modyfikowanie stanu elementów (WS_tryToggleElementState, WS_tryRangeElementState). Serwer weryfikuje token sesji, aby upewnić się, że żądanie pochodzi od uprawnionego klienta. Jeśli weryfikacja się powiedzie, serwer przesyła odpowiednią wiadomość zwrotną do Unity lub strony WWW, informując o powodzeniu lub niepowodzeniu operacji. Całość komunikacji działa w oparciu o zdarzenia WebSocketowe, które pozwalają na bieżącą wymianę danych między grą, serwerem i stroną w czasie rzeczywistym. Serwer pełni rolę centralnego punktu koordynującego wszystkie interakcje.

<h3>5. Linki</h3>
