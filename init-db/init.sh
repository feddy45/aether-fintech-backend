#!/bin/bash
set -e

export PGPASSWORD="${POSTGRES_PASSWORD:-postgres}"

echo "✅ Eseguo script SQL di inizializzazione..."
psql -U "$POSTGRES_USER" -d "$POSTGRES_DB" -f /docker-entrypoint-initdb.d/init-db.sql

echo "🎉 Inizializzazione completata!"
