#!/bin/bash
set -e

export PGPASSWORD="$POSTGRES_PASSWORD"

echo "⏳ Aspetto che il database sia pronto..."
until pg_isready -h db -U "$POSTGRES_USER" -d "$POSTGRES_DB"; do
  sleep 1
done

echo "✅ Database pronto, eseguo script di inizializzazione..."
psql -h db -U "$POSTGRES_USER" -d "$POSTGRES_DB" -f /init-db/init-db.sql

echo "🎉 Inizializzazione completata!"
