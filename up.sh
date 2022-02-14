#!/usr/bin/env bash

docker run \
    --cap-add SYS_PTRACE \
    -e 'ACCEPT_EULA=1' \
    -e 'MSSQL_SA_PASSWORD=My$eCretPazzW0rd' \
    -p 1433:1433 \
    --name sqlserver \
    -d \
    mcr.microsoft.com/azure-sql-edge
