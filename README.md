# aMuseREST_API

<h3>Back-end do webowego portalu społecznościowego przeznaczonego do zamieszczania kursów, z których mogą korzystać pozostałe osoby społeczności. </h3> 
<h1>1. Charakterystyka oprogramowania:</h1>

<h2>Nazwa skrócona:</h2> <b>aMuse</b>

<h2>Nazwa pełna:</h2> <b>Online Music Academy</b>

<h3>Opis:</h3> Portal społecznościowy umożliwiający zamieszczanie kursów oraz uczesnictwo w kursach stworzonych przez inne osoby ze społeczności . 

<h3>Cele:</h3>
- tworzenie lekcji na zasadzie artykułów z danego zagadnienia z możliwością przesłania danych binarnych
- tworzenie klas
- z poziomu klas dostęp do lekcji

<h3> Prawa autorskie </h3> 
Autorzy: Paweł Szczodrowski, Patryk Pawłowicz </br>
Licencja: Open source

<h2>2. Specyfikacja wymagań:</h2>

<h3>Wymagania funkcjonalne</h3>


Identyfikator: auth </br>
Nazwa krótka: Autentykacja </br>
Opis: Możiwość rejestracji oraz logowania do serwisu internetowego za pośrednictwem maila i hasła</br>
Identyfikacja użytkownika następuje na podstawie JWT. </br>
Priorytet: 1 </br>

Identyfikator: Bezp </br>
Nazwa krótka: Bezpieczeństwo </br>
Opis: <ul>
      <li>Hasła przechowywane w bazie danych są zaszyfrowane, administrator systemu nie ma do nich dostępu</li>
      <li>Java Web Token ma żywotność 24h - po tym czasie zapytania HTTP nie będą obsługiwane</li>
      <li>Poszczególne endpointy są zabezpieczone przed nieautoryzowanym dostępem, tylko właściciel zasobu może go edytować lub usunąć</li>
      </ul>

Priorytet: 1 </br>

Identyfikator: gc</br>
Nazwa krótka: Zarządzanie klasami</br> 
Opis: Użytkownik systemu ma możliwość przeglądania listy klas z głównego widoku strony. Może również dodawać własne klasy uzupełniając je o pola: tytuł, opis. Właściciel klasy ma możliwośc edycji, oraz usunięcia niechcianej klasy. Do każdej klasy właściciel może dodać nieograniczoną liczbę lekcji. Wchodząc na daną klasę wyświetlają się jej szczegółowe informacje oraz lista lekcji</br>
Priorytet: 1</br>

Identyfikator cc </br>
Nazwa krótka: Zarządzanie lekcjami </br>
Opis: Operacje CRUD na modelu lekcje, lekcja zawiera w sobie pola: </br>
- autor </br>
- tytuł </br>
- treść </br>
Priorytet: 2 </br>

Identyfikator: </br>
Nazwa krótka: Pytania uczestników</br>
Opis: Dodanie sekcji pytań odnoszących się do danej lekcji w postaci listy, z możliwością odwołania się do poszczególnych pytań.</br> 
Priorytet: 3</br>

<h3>Wymagania niefunkcjonalne</h3>

a) Wymagania produktowe</br>

- System będzie posiadał przyjazny interfejs graficzny oraz rozbudowane centrum pomocy w obsłudze, co umożliwi bezproblemowe użytkowanie dla wszystkich osób, niezależnie od posiadania niewielkiej lub całkowitego braku  umiejętności w obsłudze podobnych systemów.</br>
- Przewiduje się dużą niezawodność: system powinien być w stanie działać bezawaryjnie 24 godziny na dobę, z możliwą awarią lub nieaktywnością w nie więcej niż 1 dzień na miesiąc, gdzie usunięcie awarii lub ponowna aktywacja systemu nie powinna zająć doświadczonemu informatykowi dłużej niż 2 godziny.</br>
- Transfer  wszystkich danych przesyłanych między klientami a systemem zostanie zabezpieczony protokołem SSL, a wszystkie dane przechowywane przez system będą zabezpieczone poprzez zabezpieczenia systemu operacyjnego, na którym zostanie zainstalowany, a także poprzez awaryjną replikę bazy danych, co zapewni bezpieczeństwo danych przed ewentualnymi próbami włamań lub jej utratą.</br>
- Środowisko testowe powinno być stworzone w taki sposób aby funkcjonalność aplikacji była możliwa do przetestowania.</br>

b) Wymagania organizacyjne</br>

- Głównym środowiskiem działania aplikacji webowej będą komputery stacjonarne - wersja domyślna będzie stworzona pod kątem użytkowania strony aplikacji w wersji komputerowej. Będzie ona jednak również obsługiwany na urządzeniach mobilnych, takich jak tablety, smartphone'y oraz podobnych modyfikacjach tych urządzeń, jeśli tylko będą one posiadały aktywny dostęp do Internetu oraz aktualną przeglądarkę dowolnej marki.</br> 
- Ze względu na swoją dużą kompatybilność, jedynymi wymaganiami implementacyjnymi będzie w pełni sprawny serwer z bazą danych o pojemności wspomnianej wcześniej, stały dostęp do Internetu, przynajmniej jeden w pełni sprawny terminal dostępu ( komputer osobisty ) oraz przynajmniej jedna osoba z doświadczeniem  informatycznym z zakresu obsługi podobnych systemów.</br>

c) Wymagania zewnętrzne</br>

- W celu ścisłej ochrony prywatności i zapewnienia ochrony informacji konta wszystkich klientów będą zabezpieczone hasłami znanymi tylko dla nich. Zarówno personel firmy, jak i osoby zewnętrzne nie będą miały dostępu do tych kont, a użytkownik nie będzie zmuszony podawać więcej informacji przy dokonywaniu płatności niż jest to konieczne.</br>

<h2> 5. Architektura systemu/oprogramowania </h2>

A. Architektura rozwoju</br>

Lp. 1 </br>
Nazwa produktu: ASP .NET Core </br>
Przeznaczenie produktu: Warstwa API systemu </br>
Wersja: 5 </br>

Lp. 2 </br>
Nazwa produktu: Biblioteka klas C# </br>
Przeznaczenie produktu: Warstwa domenowa i warstwa infrastruktury </br>
Wersja: Core </br>

Lp. 3 </br>
Nazwa produktu: NUnit </br>
Przeznaczenie produktu: Testy jednostkowe, end to end </br>
Wersja: 13 </br>

Lp. 4 </br>
Nazwa produktu: VUE </br>
Przeznaczenie produktu: Warstwa Front end </br>
Wersja: 3 </br>

Lp. 5 </br>
Nazwa produktu: MsSQL </br>
Przeznaczenie produktu: baza danych </br>
Wersja: 11</br>


B. Architektura uruchomieniowa:

Lp. 1</br>
NET Core</br>
Wersja: 5</br>

Lp. 2 </br>
Baza danych MsSQL</br>
Wersja: 11</br>


