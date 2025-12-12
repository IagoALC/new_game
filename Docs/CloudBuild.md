# Unity Cloud Build (passo a passo)

## Pré-requisitos
- Projeto registrado no Unity Dashboard (Organization e Project ID).
- Acesso ao Unity Cloud Build (UCB) e API Key (Dashboard > DevOps > Build Automation > API credentials).
- Repositório git com acesso via SSH: `git@github.com:IagoALC/new_game.git` (branch `main`).
- Scenes reais (.unity) adicionadas em Build Settings (Bootstrap, Hub, Puzzle) — hoje há placeholders, substitua antes do primeiro build.
- Para Android: keystore (upload) e senha; para iOS: perfil/provisioning e certificado (.p12) com senha.

## Configuração inicial
1. No Dashboard: DevOps > Build Automation > Set up project.
2. Conectar repositório: Git (SSH), URL `git@github.com:IagoALC/new_game.git`, branch `main`.
3. Selecionar versão do Unity igual à usada localmente.
4. Adicionar Build Targets:
   - Android: setar keystore/alias/senhas; definir App ID (ex.: com.company.game).
   - iOS: subir .p12 + provisioning; setar bundle ID igual ao Android.
5. Opcional: configurar variáveis de ambiente (API keys de Ads/Analytics/Remote Config) em Secrets do UCB.

## Gatillhos e artefatos
- Trigger: a cada commit em `main` ou somente sob tag (ex.: `build-*`).
- Artefatos: ativar zip/apk/aab/ipa; manter 5–10 builds recentes.
- Cache: habilitar para acelerar builds.

## API (para automação)
- Endpoint: `https://build-api.cloud.unity3d.com/api/v1/orgs/{orgid}/projects/{projectid}/buildtargets/{targetid}/builds`.
- Headers: `Authorization: Basic <api-key>`, `Content-Type: application/json`.
- Body mínimo: `{ "clean": false }`.
- Use para disparar build manual ou via GitHub Actions.

## GitHub Actions (exemplo de trigger UCB)
- Criar segredo `UCB_API_KEY`, `UCB_ORG_ID`, `UCB_PROJECT_ID`, `UCB_TARGET_ID`.
- Workflow (resumo): ao push/tag, rodar job que faz curl no endpoint acima com os secrets.

## Checklist antes do primeiro build
- Substituir cenas placeholder por `.unity` reais e adicioná-las em Build Settings.
- Conferir Player Settings: Company Name, Product Name, Bundle ID, Versão.
- Confirmar dependências de Ads/Analytics/Billing/Remote Config importadas.
- Atualizar `.gitignore` se necessário para evitar Library/Temp.

## Troubleshooting rápido
- Erro de scenes: verifique Build Settings e caminhos das cenas.
- Falha de SDK/versão: alinhar versão de Unity local e UCB.
- Keystore/provisioning inválidos: reenviar credenciais corretas.
