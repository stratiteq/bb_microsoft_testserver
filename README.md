# Test Server
ASP.NET Core stöder interationstester med hjälp av en test web-host som kör tester in-memory (Testserver).

# Integrationstester vs. Unittester
Integrationstester testar systemets komponenter tillsammans, databaser, filsystem, request/response pipelinen etc.
Dessa tar längre tid och är mer krävande än vanliga unit tester. Unit tester används som bekant för att isolerat testa enskilda enheter (metoder vanligtvis) och dess logik.

Unittester testar implementation men ska inte kommunicera med databaser eller ha andra beroenden, istället används fakes eller mocks.

Integrationstester däremot använder riktiga komponenter och skriver/läser till och från databaser mm.
Eftersom integrationstester kräver mer minne/cpu etc. och tar längre tid bör man försöka undvika onödiga testfall med integrationstester och köra dessa för de mer viktiga scenarios. 

## Integrationstester med TestServer
Vanligtvis används en annan konfiguration än den för produktion vid integrationstester. TestServer är fullt konfigurerbar vid startup för att peka ut den setup man vill bygga.
Nuget för att skapa en in-memory testserver är: Microsoft.AspNetCore.Mvc.Testing, denna hanterar följande tasks:
  - Kopierar dependency klasser (*.deps) från SUT (System Under Test) till testprojektets bin folder
  - Sätter content root till SUTs projekt root så att statiska filer och vyer finns tillgängliga när testerna exekveras
  - Ger tillgång till WebApplicationFactory klassen för att bootstrappa SUT med TestServer

### Kom igång med koden
1. Test projektet importerar nugets: 
  - Microsoft.AspNetCore.Mvc.Testing
  - using Microsoft.Extensions.Configuration
  - using Microsoft.Extensions.Configuration.json
1. I Testprojektet behöver en WebHostBuilder sättas upp
   - WebHostBuilder behöver en startup class, denna kan vara densamma som i SUT eller en egen fil beroende på behovet av separata miljöer.
1. Tänk på att TestServer implementerar IDisposable, det är därför bra för minnet att implmentera IDisposable där du sätter upp din TestServer instans 

Notera att i ASP.NET Core 2.1 har ditt API en referens till Microsoft.AspNetcore.App vilket skapar problem eftersom följande nugets behöver finnas för TestServer att kunna köra testerna.
Dessa kan läggas till som separata nugets i API projektet (obs, detta är en lösning, det finns säkert andra även om jag inte hittade någon snabbt).
- Microsoft.AspNetCore.HttpsPolicy
- Microsoft.AspNetCore.Mvc
- Microsoft.AspNetCore.Diagnostics

