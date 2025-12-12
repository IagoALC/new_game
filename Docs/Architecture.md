# Arquitetura e Boas Práticas

## Camadas
- Core: inicialização, carregamento de cena, save/profile, DI leve.
- Services: Ads, Analytics, Remote Config, Billing (futuro), Push (futuro).
- Gameplay: puzzle, níveis, boosters, HUD de partida.
- Meta: economia (moedas/energia), upgrades de hub, missões/eventos, loja.
- UI: telas e HUDs; separar lógica (presenters/controllers) de views.

## Fluxo de cena sugerido
- Cena Bootstrap: inicializa serviços e carrega Hub.
- Hub: navegação para Puzzle, Upgrades, Loja, Eventos, Missões.
- Puzzle: partida rápida; ao concluir, retorna ao Hub.

## Dados e persistência
- Perfil leve em JSON (PlayerPrefs ou backend Firebase) contendo moedas, gems, energia, progresso de níveis, configs do hub.
- Sincronizar on app focus/pause; usar Remote Config para parâmetros (energia, recompensas, frequência de ads).

## Escalabilidade
- Configurações via ScriptableObjects (níveis, economia, missões, eventos).
- Serviços desacoplados via singletons simples; substituir por injeção conforme crescer.
- Eventos/telemetria centralizados no AnalyticsService.

## Boas práticas
- Evitar lógica em UI; usar presenters/mediadores.
- Seeds fixas para níveis iniciais e testes.
- Limitar alocação por frame; evitar GC spikes.
- Separar assets por cena para reduzir peso de build; usar Addressables quando necessário.
