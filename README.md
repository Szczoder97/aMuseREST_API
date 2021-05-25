# aMuseREST_API

<h3>Back-end do webowego portalu społecznościowego przeznaczonego do zamieszczania kursów, z których mogą korzystać pozostałe osoby społeczności. </h3> 
<h2>1. Charakterystyka oprogramowania:</h2>

<h2>Nazwa skrócona:</h2> <b>aMuse</b>

<h2>Nazwa pełna:</h2> <b>Online Music Academy</b>

<h3>Opis:</h3> Aplikacja internetowa gromadząca społeczność zainteresowaną edukacją muzyczną. </br> 
Każdy użytkownik może dzielić się swoją wiedzą oraz czerpać inspirację od bardziej doświadczonych osób. </br>
Serwis jest bezpłatny a wszystkie informacje udostępnione na nim mają za zadanie rozwijać pasje jego członków. </br>

<h3>Cele:</h3>
- tworzenie lekcji na zasadzie artykułów z danego zagadnienia z możliwością przesłania danych binarnych
- tworzenie klas
- z poziomu klas dostęp do lekcji

<h3> Prawa autorskie </h3> 
Autorzy: Paweł Szczodrowski, Patryk Pawłowicz </br>
Licencja: Open source

<h2>2. Specyfikacja wymagań:</h2>

<h3>Wymagania funkcjonalne</h3>


<b>Identyfikator: AUTH </b></br>
<b>Nazwa krótka: Autentykacja </b></br>
Opis: <ul> <li>Możiwość rejestracji oraz logowania do serwisu internetowego za pośrednictwem maila i hasła</li>
      <li>Identyfikacja użytkownika następuje na podstawie JWT.</li>
      </ul>
Priorytet: 1 </br>

<b>Identyfikator: SEC </b></br>
<b>Nazwa krótka: Bezpieczeństwo </b></br>
Opis: <ul>
      <li>Hasła przechowywane w bazie danych są zaszyfrowane, administrator systemu nie ma do nich dostępu</li>
      <li>Java Web Token ma żywotność 24h - po tym czasie zapytania HTTP nie będą obsługiwane</li>
      <li>Poszczególne endpointy są zabezpieczone przed nieautoryzowanym dostępem, tylko właściciel zasobu może go edytować lub usunąć</li>
      </ul>

Priorytet: 1 </br>

<b>Identyfikator: CC </b></br>
<b>Nazwa krótka: Zarządzanie klasami </b></br> 
Opis: <ul><li>Uwierzytelniony użytkownik systemu ma możliwość przeglądania listy klas z głównego widoku strony.</li> 
      <li>Może również dodawać własne klasy uzupełniając je o pola: tytuł, opis. </li>
      <li>Właściciel klasy ma możliwośc edycji, oraz usunięcia niechcianej klasy. </li>
      <li>Do każdej klasy właściciel może dodać nieograniczoną liczbę lekcji.</li>
      <li>Wchodząc na daną klasę wyświetlają się jej szczegółowe informacje oraz lista lekcji</li></ul>
      
Priorytet: 1</br>

<b>Identyfikator LC </b></br>
<b>Nazwa krótka: Zarządzanie lekcjami </b></br>
Opis: <ul><li>Uwierzytelniony użytkownik systemu ma możliwość przeglądania listy lekcji z głównego widoku klasy.</li> 
      <li>Właściciel klasy może tworzyć przypisane do niej lekcje</li>
      <li>Właściciel klasy ma możliwośc edycji, oraz usunięcia niechcianej lekcji. </li>
      <li>Tworząc zasób lekcji należy podać tytuł, zawartość lekcji oraz link do filmiku na serwisie YouTube</li>
      <li>Wchodząc na daną lekcję wyświetlają się jej zawartość oraz okienko z filmiem</li></ul>
Priorytet: 2 </br>

<b>Identyfikator: CONTACT </b></br>
<b>Nazwa krótka: Sekcja kontakt </b></br>
Opis: Umożliwienie komunikacji z autorem poszczególnych klas</br> 
Priorytet: 3</br>

<h3>Wymagania niefunkcjonalne</h3>

a) <b>Wymagania produktowe</b></br>
<ol>
<li>System będzie posiadał przyjazny interfejs graficzny, co umożliwi bezproblemowe użytkowanie dla wszystkich osób, niezależnie od posiadania niewielkiej lub całkowitego braku  umiejętności w obsłudze podobnych systemów.</li>
<li>Przewiduje się dużą niezawodność: system powinien być w stanie działać bezawaryjnie 24 godziny na dobę, z możliwą awarią lub nieaktywnością w nie więcej niż 1 dzień na miesiąc, gdzie usunięcie awarii lub ponowna aktywacja systemu nie powinna zająć doświadczonemu informatykowi dłużej niż 2 godziny.</li>
<li> Wszystkie dane przechowywane przez system będą zabezpieczone poprzez zabezpieczenia systemu operacyjnego, na którym zostanie zainstalowany.</li>
<li> Środowisko testowe powinno być stworzone w taki sposób aby funkcjonalność aplikacji była możliwa do przetestowania.</li>
</ol>

b) <b>Wymagania organizacyjne</b></br>

<ol>
<li> Głównym środowiskiem działania aplikacji webowej będą komputery stacjonarne oraz laptopy - wersja domyślna będzie stworzona pod kątem użytkowania strony aplikacji w wersji komputerowej. Będzie ona jednak również obsługiwana na urządzeniach mobilnych, takich jak tablety, smartphone'y oraz podobnych modyfikacjach tych urządzeń, jeśli tylko będą one posiadały aktywny dostęp do Internetu oraz aktualną przeglądarkę dowolnej marki. </li> 
<li> Ze względu na swoją dużą kompatybilność, jedynymi wymaganiami implementacyjnymi będzie w pełni sprawny serwer z bazą danych, stały dostęp do Internetu, przynajmniej jeden w pełni sprawny terminal dostępu ( komputer osobisty ) oraz przynajmniej jedna osoba z doświadczeniem informatycznym z zakresu obsługi podobnych systemów.</li>
</ol>

c) <b>Wymagania zewnętrzne</b></br>
<ol>
<li> W celu ścisłej ochrony prywatności i zapewnienia ochrony informacji konta wszystkich klientów będą zabezpieczone hasłami znanymi tylko dla nich. Zarówno personel firmy, jak i osoby zewnętrzne nie będą miały dostępu do tych kont.</li>
</ol>

<h2> 5. Architektura systemu/oprogramowania </h2>

A. <b>Architektura rozwoju</b></br>

Lp. 1 </br>
Nazwa produktu: ASP .NET Core </br>
Przeznaczenie produktu: Warstwa API systemu </br>
Wersja: 5 </br>

Lp. 2 </br>
Nazwa produktu: Biblioteka klas C# </br>
Przeznaczenie produktu: Warstwa domenowa i warstwa infrastruktury </br>
Wersja: Core </br>

Lp. 3 </br>
Nazwa produktu: AutoMapper </br>
Przeznaczenie produktu: Mapowanie obiektów domentowych na obiekty DTO </br>
Wersja: 8.1.1 </br>

Lp. 4 </br>
Nazwa produktu: NUnit </br>
Przeznaczenie produktu: Testy jednostkowe, end to end </br>
Wersja: 13 </br>
Lp. 5 </br>
Nazwa produktu: NUnit </br>
Przeznaczenie produktu: Testy jednostkowe, end to end </br>
Wersja: 13 </br>

Lp. 6 </br>
Nazwa produktu: VUE </br>
Przeznaczenie produktu: Warstwa Front end </br>
Wersja: 3 </br>

Lp. 7 </br>
Nazwa produktu: MsSQL </br>
Przeznaczenie produktu: baza danych </br>
Wersja: 11</br>

Lp. 8 </br>
Nazwa produktu: Entity Framework Core SQLServer
Przeznaczenie produktu: Warstwa komunikacji interfejsu Web API z bazą danych MsSQL, mapowanie modeli domenowych na tabele w bazie danych </br>
Wersja: 5.0.6

Lp. 9 </br>
Nazwa produktu: IdentityModel.Token.JWT
Przeznaczenie produktu: Generowanie JWT </br>
Wersja: 6.11.0

Lp. 10 </br>
Nazwa produktu: Microsoft.AspNetCore.Authentication.JwtBearer
Przeznaczenie produktu: Autoryzacja na podstawie tokenu JWT </br>
Wersja: 5.0.6


B. <b>Architektura uruchomieniowa: </b>

Lp. 1</br>
Nazwa produktu: .NET Core</br>
Przeznaczenie produktu: Środowisko uruchomieniowe
Wersja: 5</br>

Lp. 2 </br>
Nazwa produktu: Baza danych MsSQL</br>
Przeznaczenie produktu: Przechowywanie danych użytkowników
Wersja: EXPRESS </br>

Lp. 3</br>
Nazwa produktu: Swashbuckle.AspNetCore</br>
Przeznaczenie produktu: Uruchomienie klienta Swagger w celu testowania manualnego
Wersja: 5.6.3 </br>

Lp. 4</br>
Nazwa produktu: Swashbuckle.AspNetCore.Filters</br>
Przeznaczenie produktu: Rozszerzenie funkcjonalności klienta Swagger o autentykację
Wersja: 7.0.2</br>

