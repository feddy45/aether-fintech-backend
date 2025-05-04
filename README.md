# Aether Fintech Backend

Aether Fintech Backend è un'applicazione backend sviluppata in **.NET 9**, pensata per gestire le funzionalità principali di un sistema fintech, come carte, trasferimenti e bonifici. Questo progetto utilizza un'architettura modulare ed è pensato per essere facilmente estendibile.

## Prerequisiti

Prima di avviare l'applicazione, assicurarsi di avere installato:

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/) (se non incluso nel tuo Docker Desktop)

## Avvio del database

Per avviare il database, esegui il seguente comando dalla root del progetto:

```bash
docker-compose up -d
```

Questo comando avvierà i containers in background. Puoi controllare che tutto sia funzionante con:

```bash
docker ps
```

Per fermare i containers:

```bash
docker-compose down
```

## Avvio dell'applicazione

Una volta avviato il database, puoi eseguire l'applicazione con il comando:

```bash
dotnet run --project Web.Api
```

Una volta avviata l'applicazione si può accedere a Swagger tramite l'indirizzo `http://localhost:5118/api/v1/swagger/index.html`.

Altrimenti, se si ha un ide che supporta l'avvio di progetti, è possibile avviare il progetto `Web.Api` direttamente dall'IDE e automaticamente verrà aperto lo Swagger dell'applicazione.

## Note aggiuntive

- Il file `appsettings.Development.json` contiene le configurazioni di sviluppo.
- Il progetto è suddiviso in moduli, ognuno con i propri layer (`Api`, `Core`, `DataAccess`), per favorire la manutenibilità e l'espandibilità.

## Accesso all'applicazione
Lanciando lo script Docker viene inizializzato il database con due utenti predefiniti: 
- `federico`
- `giulia`

La password, identica per tutti e due gli utenti, è `Aether123.`
