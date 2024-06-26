set "diretorio_atual=%CD%"

docker compose up -d --build

start "GerenciadorClientes" http://localhost:8080/