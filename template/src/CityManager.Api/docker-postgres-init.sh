#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
	CREATE DATABASE "CityManager";
	CREATE USER "CityManager" WITH ENCRYPTED PASSWORD 'CityManager';
	GRANT ALL PRIVILEGES ON DATABASE "CityManager" TO "CityManager";
	\c "CityManager" "$POSTGRES_USER"
	GRANT ALL ON SCHEMA public TO "CityManager";
EOSQL