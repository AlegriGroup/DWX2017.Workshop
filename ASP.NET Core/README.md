# ASP.NET Core - Schritte und Übungen

## 1 - Projekt erstellen

Erstellt ein ASP.NET Core Projekt:
- Name: `DWX17.WorkShop.WebApp`
- basierend auf .NET Core
- ohne Docker
- ohne Authentifizierung
- als ASP.NET Core MVC Webanwendung

## 2 - AppSettings

Erstellt ein eigenes AppSettings-Element für euren PC:

`appsettings.<pcname>.json`

## 3 - Depenendency Injection

Erstellt zwei oder mehrere Services.

Beispiel:

- `ITextService` : ein Interface, das eine `GetText` Methode zur Verfügung stellt.
- `HelloWorldTextService` : Eine Klasse, die `ITextService` implementiert und die `GetText` Methode `hello world` zurück gibt.
- `DwxTextService` : Eine Klasse, die `ITextService` implementiert und die `GetText` Methode `hello from dwx` zurück gibt.

## 4 - Service Injection

Injeziert die Services in einen Controller.
Lasst den Text der `GetText` Methode in einer beliebigen View anzeigen.

## 5 - Testen der Services

Erstellt ein neues Projekt in der Solution:

- Name: `DWX17.WorkShop.WebApp.UnitTests`
- XUnit Projekt Vorlage

Schreibt einen Test, der eure Services vollständig testet

## 6 - Docker

Fügt Docker zum Projekt hinzu.

Startet das Debugging im Projekt und versucht, im Docker Container einen Breakpoint zu setzen und zu debuggen.
