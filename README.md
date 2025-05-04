# Aether Fintech Backend

Aether Fintech Backend è un'applicazione backend sviluppata in **.NET 9**, pensata per gestire le funzionalità principali di un sistema fintech, come carte, trasferimenti e bonifici. Questo progetto utilizza un'architettura modulare ed è pensato per essere facilmente estendibile.

## Prerequisiti

Prima di avviare l'applicazione, assicurarsi di avere installato:

- [.NET 9 SDK](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/) (se non incluso nel tuo Docker Desktop)

## Avvio del database

Per avviare il database (e gli eventuali altri servizi definiti nel `docker-compose.yaml`), esegui il seguente comando dalla root del progetto:

```bash
docker-compose up -d
```

Questo comando avvierà i contenitori in background. Puoi controllare che tutto sia funzionante con:

```bash
docker ps
```

Per fermare i contenitori:

```bash
docker-compose down
```

## Avvio dell'applicazione

Una volta avviato il database, puoi eseguire l'applicazione con il comando:

```bash
dotnet run --project src/Aether.Fintech.Api
```

Assicurati di modificare il percorso nel comando `--project` in base alla struttura effettiva della tua soluzione, se diversa.

## Note aggiuntive

- Il file `appsettings.Development.json` contiene le configurazioni di sviluppo.
- Il progetto è suddiviso in moduli, ognuno con i propri layer (`Api`, `Core`, `DataAccess`), per favorire la manutenibilità e l'espandibilità.
