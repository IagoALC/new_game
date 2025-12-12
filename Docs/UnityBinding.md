# Ligações rápidas no Unity

## Gerar assets padrão
- Menu `Tools/Setup/Criar Configurações Básicas` cria:
  - EconomyConfig (energia/recompensa base)
  - LevelConfig_001 e LevelCatalog
  - DailyPlay mission
  - WeeklyEvent
  - Upgrades (prod_base, cap_base, aest_base)

## Cena Bootstrap.unity
- GameObjects: Bootstrap, ProfileStorage, EconomyWallet, EnergySystem, MissionManager, EventManager, DailyStreak, BillingService (opcional).
- Referenciar EconomyConfig em EnergySystem.
- Garantir que Ads/Analytics/RemoteConfig prefabs existam ou usar stubs atuais.

## Cena Hub.unity
- UI: botões ligar em HubUIController (PlayPuzzle, OpenStore, OpenUpgrades, OpenEvents, ClaimStreak).
- HUD: ligar HudController em textos de moedas/energia e refs de wallet/energy.
- Store: ligar StoreController a botões (StarterPack, CoinsPack, AdEnergy).
- Upgrades: ligar UpgradeUIController em cada card de upgrade, setar upgradeId e textos; em cena, referenciar UpgradeManager e adicionar as UpgradeDefinition criadas pelo gerador.

## Cena Puzzle.unity
- PuzzleGameController referenciar EnergySystem, EconomyWallet e um LevelConfig (ou buscar via LevelCatalog).
- Ao concluir/derrotar, retornar ao Hub via SceneLoader.

## SDKs
- Substituir stubs de Ads/Analytics/Billing/RemoteConfig pelos SDKs (AdMob/LevelPlay, Firebase/Unity Analytics, Google Play Billing/Apple IAP, Firebase Remote Config).
- Manter assinaturas dos métodos para minimizar refactor.
